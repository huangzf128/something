with open("text.txt", "r", encoding='utf-8') as f:
    for line in f.readlines():
        print(line.encode('cp932'))

print("end")
