empty_json = {}


for i in range(0,42):
    empty_json[str(i)]={
        "object_url":f'/AR/patt_file/{str(i)}.patt',
        "redirect_url":"https://raw.githubusercontent.com/siddu1998/siddu1998.github.io/master/resilience/images/afunsudoku.png",
        "unlock_text":f"SOME TEXT FOR THIS TARGET IMAGE {str(i)}"

    }


print(empty_json)