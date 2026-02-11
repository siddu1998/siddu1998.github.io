/**
 * Cloudflare Worker — X/Twitter API CORS Proxy for CanvX
 * 
 * DEPLOY:
 * 1. Go to https://dash.cloudflare.com → Workers & Pages → Create Worker
 * 2. Paste this code → Deploy
 * 3. In CanvX Settings, set CORS Proxy URL to your worker URL
 */

const CORS_HEADERS = {
  'Access-Control-Allow-Origin': '*',
  'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
  'Access-Control-Allow-Headers': 'Content-Type, Authorization, X-Target-URL, X-Auth-Header',
  'Access-Control-Max-Age': '86400',
};

export default {
  async fetch(request) {
    if (request.method === 'OPTIONS') {
      return new Response(null, { status: 204, headers: CORS_HEADERS });
    }

    const targetUrl = request.headers.get('X-Target-URL');
    if (!targetUrl) {
      return new Response(
        JSON.stringify({ error: 'Missing X-Target-URL header' }),
        { status: 400, headers: { 'Content-Type': 'application/json', ...CORS_HEADERS } }
      );
    }

    if (!targetUrl.startsWith('https://api.x.com/') && !targetUrl.startsWith('https://api.twitter.com/')) {
      return new Response(
        JSON.stringify({ error: 'Only api.x.com URLs are allowed' }),
        { status: 400, headers: { 'Content-Type': 'application/json', ...CORS_HEADERS } }
      );
    }

    try {
      const forwardHeaders = new Headers();

      // Use X-Auth-Header if provided (OAuth 1.0a), otherwise fall back to Authorization
      const oauthHeader = request.headers.get('X-Auth-Header');
      const authHeader = request.headers.get('Authorization');
      if (oauthHeader) {
        forwardHeaders.set('Authorization', oauthHeader);
      } else if (authHeader) {
        forwardHeaders.set('Authorization', authHeader);
      }

      const proxyResponse = await fetch(targetUrl, {
        method: request.method,
        headers: forwardHeaders,
        body: request.method !== 'GET' && request.method !== 'HEAD' ? await request.text() : undefined,
      });

      const responseBody = await proxyResponse.text();
      return new Response(responseBody, {
        status: proxyResponse.status,
        headers: {
          'Content-Type': proxyResponse.headers.get('Content-Type') || 'application/json',
          ...CORS_HEADERS,
        },
      });
    } catch (err) {
      return new Response(
        JSON.stringify({ error: 'Proxy fetch failed: ' + err.message }),
        { status: 502, headers: { 'Content-Type': 'application/json', ...CORS_HEADERS } }
      );
    }
  },
};
