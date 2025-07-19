import json
import os

first_name = input("Enter your first name: ")
last_name = input("Enter your last name: ")

user_info = {
    "first_name": first_name,
    "last_name": last_name
}

file_name = "First and Last name.json"

documents_folder = os.path.join(os.path.expanduser("~"), "Documents")
full_path = os.path.join(documents_folder, "user_info.json")

with open(full_path, "w") as json_file:
    json.dump(user_info, json_file, indent=4)

print(f"\nYour name has been saved in: {full_path}")
