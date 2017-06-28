import os, re, codecs

sql_path = os.path.join(os.getcwd(), "sql_new.txt")

def read_file():
    with codecs.open(sql_path, 'r', 'utf-8') as f:
        return f.read().splitlines()

def write_file(lines):
    with codecs.open(sql_path, 'w', 'utf-8') as f:
        for line in lines:
            f.write(line + "\n")

sqls = read_file()

formated_sql = []
for sql in sqls:
    formated_sql.append("bufSql.append(\"" + sql + "\");")

write_file(formated_sql)
