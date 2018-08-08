import cx_Oracle, zenhan
import sys, os ,re, configparser, codecs
from pykakasi import kakasi

table_name = "T_EMPWEEKKYUSYUTU"

def connect_Oracle( server, port, user, pswd, service ):
    try:
        conn = cx_Oracle.connect( user, pswd, server + ':' + port + '/' + service , encoding = "utf-8")
        cur = conn.cursor()
        return ( cur , conn )
    except ( cx_Oracle.DatabaseError ) as ex:
        print ( sys.exc_info()[1] )
        raise ex

def exec_Oracle_SQL( cur, sql ):
    try:
        cur.execute( sql )
        rows = cur.fetchall()
        return ( rows )
    except ( cx_Oracle.DatabaseError ) as ex:
        print ( sys.exc_info()[1] )
        raise ex

def create_dao(tem_file_path, encoding='utf-8'):

    new_path = tem_file_path.replace(".txt", "_new.txt")
    lineno = 0
    with codecs.open(tem_file_path, encoding=encoding) as orig:
        with codecs.open(new_path, 'wb', encoding=encoding) as new_file:
            for line in orig:
                lineno += 1
                yield line, lineno, new_file

def replaceEntity(new_file, line, old, news):
    for c in news:
        new_file.write(line.replace(old, c.capitalize()))

def replaceCondition(new_file, line, old, news):
    for i, c in enumerate(news):
        if (i == 0):
            subline = line.replace(old, c).replace("AND", "   ")
        else:
            subline = line.replace(old, c)
        new_file.write(subline)

def replaceCol(new_file, line, old, news):
    for i, c in enumerate(news):
        if (i == 0):
            subline = line.replace(old, c).replace(",", " ")
        else:
            subline = line.replace(old, c)
        new_file.write(subline)


def insert(line, new_file):

    if ("{inscoltemplate}" in line):

        replaceCol(new_file, line, "{inscoltemplate}", cols_pkey + cols)

    elif ("{questions}" in line):
        q = []
        for _ in range(len(cols_pkey) + len(cols)):
            q.append("?")

        new_file.write(line.replace("{questions}", ",".join(q)))

    elif ("{insentitytemplate}" in line):

        replaceEntity(new_file, line, "{insentitytemplate}", cols_pkey + cols)

    else :
        return False

    return True

def update(line, new_file):

    updCols = [c for c in cols if c != "DELETEFLG"]
    updCols_pkey = cols_pkey.copy()
    updCols_pkey.append("DELETEFLG")

    if ("{updcoltemplate}" in line):

        replaceCol(new_file, line, "{updcoltemplate}", updCols)

    elif ("{updconditiontemplate}" in line):
        
        replaceCondition(new_file, line, "{updconditiontemplate}", updCols_pkey)


    elif ("{updentitytemplate}" in line):

        replaceEntity(new_file, line, "{updentitytemplate}", updCols + updCols_pkey)
    else:
        return False

    return True

def logicDelete(line, new_file):

    if ("{logindeltemplate}" in line):

        replaceCondition(new_file, line, "{logindeltemplate}", cols_pkey)

    elif ("{logindelentitytemplate}" in line):

        replaceEntity(new_file, line, "{logindelentitytemplate}", cols_pkey)
    else:
        return False
    
    return True

def delete(line, new_file):

    if ("{deltemplate}" in line):

        replaceCondition(new_file, line, "{deltemplate}", cols_pkey)

    elif ("{delentitytemplate}" in line):

        replaceEntity(new_file, line, "{delentitytemplate}", cols_pkey)
    else:
        return False

    return True

def select(line, new_file):

    if ("{selcoltemplate}" in line):

        replaceCol(new_file, line, "{selcoltemplate}", cols_pkey + cols)

    elif ("{selconditiontemplate}" in line):

        replaceCondition(new_file, line, "{selconditiontemplate}", cols_pkey)

    elif ("{selentitytemplate}" in line):

        replaceEntity(new_file, line, "{selentitytemplate}", cols_pkey)
    else:
        return False

    return True


if __name__ == '__main__':

    cols = []
    cols_pkey = []

    cur, conn = connect_Oracle( '192.168.246.150', '1521', 'wkt', 'wkt', 'orcl' )
    rows = exec_Oracle_SQL( cur, "SELECT cols.column_name, cons.pkey FROM all_tab_cols cols left join (SELECT column_name, owner, 1 as pkey FROM all_cons_columns WHERE constraint_name = (SELECT constraint_name FROM all_constraints WHERE UPPER(table_name) = UPPER('T_EMPWEEKKYUSYUTU') AND CONSTRAINT_TYPE = 'P' AND owner = 'WKT')) cons on cols.column_name = cons.column_name and cols.owner = cons.owner WHERE UPPER(cols.table_name) = UPPER('T_EMPWEEKKYUSYUTU') AND cols.owner = 'WKT' order by cols.column_id" )

    for row in rows:
        if row[1] == 1:
            cols_pkey.append(row[0])
        else:
            cols.append(row[0])

    for line, lineno, new_file in create_dao("template.txt", "shift-jis"):
        line = line.replace("M_TEMPLATE", table_name)
        if insert(line, new_file):
            pass
        elif update(line, new_file):
            pass
        elif logicDelete(line, new_file):
            pass
        elif delete(line, new_file):
            pass
        elif select(line, new_file):
            pass
        else:    
            new_file.write(line)
    
    print('The end ...')  