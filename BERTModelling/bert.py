from bertopic import BERTopic
# from sklearn.datasets import fetch_20newsgroups
import pandas as pd
from sklearn.feature_extraction.text import CountVectorizer

docs = pd.read_csv('../../DATA/NEW_ALL_RELIGION_FULL_POST.csv')

docs = docs['CONTENT'].tolist()

print('running')
vectorizer_model = CountVectorizer(ngram_range=(1, 2), stop_words="english", min_df=10)
topic_model = BERTopic(vectorizer_model=vectorizer_model)
topics, probs = topic_model.fit_transform(docs)
topic_model.save("test_model")
print(topic_model.get_topic_info())

