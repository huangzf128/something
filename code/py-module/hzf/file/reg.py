import os, re

file_name = "abc/1.jpg"
new = re.sub(r"(.*/)(\d)(\.jpg)$", r"\g<1>0\2\3", file_name)
print(new)

inputStr = "hello 111 world 111 and 111"
replacedStr = re.sub(r"\d+", "222", inputStr, 2)
#print(replacedStr)

a_string = "abc xxx abc yyy"
new_string = re.sub("xxx|yyy", "abc", a_string)
#print(new_string)

#print("c:\\code\\python\\bin")

a = re.sub(r'(\d{4})-(\d{2})-(\d{2})', r'\2-\3-\1', '2018-06-07')
#print(a)