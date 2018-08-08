import cx_Oracle, zenhan
import sys, os ,re, configparser
from pykakasi import kakasi

def connect_Oracle( server, port, user, pswd, service ):
    try:
        conn = cx_Oracle.connect( user, pswd, server + ':' + port + '/' + service , encoding = "utf-8")
        #conn = cx_Oracle.connect( user, pswd, server + ':' + port + '/' + service )
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

def kanji2kana(name):
    k = kakasi()
    k.setMode("J", "K")
    conv = k.getConverter()
    return zenhan.z2h(conv.do(name))

if __name__ == '__main__':

    #os.environ["NLS_LANG"] = "JAPANESE_JAPAN.JA16SJISTILDE"

    cur, conn = connect_Oracle( '192.168.246.150', '1521', 'WATAMIKINTAI', 'WATAMIKINTAI', 'orcl' )
    rows = exec_Oracle_SQL( cur, "select EMPNAME,EMPCODE,EMPCODE2,MTKYSTRD from m_emp" )
    #rows = exec_Oracle_SQL( cur, "select EMPNAME from m_emp where rownum < 100" )
    for row in rows:
        name = row[0]
        
        if (re.search(r'[\u4E00-\u9FD0]', name) is not None):
            newname = re.search(r'.{2}', name).group() + "太郎"
            if (newname == name):
                newname = re.search(r'.{2}', name).group() + "五郎"
        else:
            l = len(name) // 2
            newname = re.search(r'.{' + str(l) + '}', name).group() + "タロウ"
            if (newname == name):
                newname = re.search(r'.{2}', name).group() + "ゴロウ"

        cur.execute("update m_emp set empname = '" + newname + "', KANA = '" + kanji2kana(newname) + "' \
                            where EMPCODE = '" + str(row[1]) + "' and EMPCODE2 = '" + row[2] + "' and MTKYSTRD = '" + row[3] + "' " )
    conn.commit()
    print('The end ...')