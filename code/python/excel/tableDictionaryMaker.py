from openpyxl import load_workbook
import os, re, codecs

table_folder_path = os.path.join(os.getcwd(), "tables")
table_dictionary_path = os.path.join(os.getcwd(), "dictionary.mac")
# dictionary_template = "replaceallfast \"(\\\\.|\\\\s)[comment]\", \" [name]\", regular"
dictionary_template = "[comment],,[name]"

# def read_excel
# def write_table_info(table_name, col_infos)

class excel_reader(object):
    def __init__(self, path):
        self.Wb = load_workbook(filename=path)
        self.excel_type(path)

    def get_col_infos(self):
        col_infos = {}
        if self.type == 1:
            sheet = self.Wb.worksheets[0]
            i = 8
            while sheet["C" + str(i)].value is not None and len(sheet["C" + str(i)].value) > 0:
                col_infos[sheet["B" + str(i)].value] = sheet["C" + str(i)].value
                i = i + 1
        else:
            sheet = self.Wb.worksheets[2]
            i = 15
            while sheet["N" + str(i)].value is not None:
                col_infos[sheet["C" + str(i)].value] = sheet["N" + str(i)].value
                i = i + 2
        return col_infos

    def get_table_name(self):
        tab_name = {}
        if self.type == 1:
            sheet = self.Wb.worksheets[0]
            tab_name[sheet["H5"].value] = sheet["C5"].value
        else:
            sheet = self.Wb.worksheets[2]
            tab_name[sheet["AJ7"].value] = sheet["N7"].value
        return tab_name

    def excel_type(self, path):
        if ("テーブルレイアウト" in path):
            # old
            self.type = 1
        else:
            # new
            self.type = 2

    def close(self):
        self.Wb.close()

def get_table_info(excel_path):
    excel = excel_reader(excel_path)
    tab_info = excel.get_table_name()
    tab_info.update(excel.get_col_infos())
    excel.close()
    return tab_info

def write_dictionary(col_infos):
    with codecs.open(table_dictionary_path, "a", "utf-8") as f:
        for value, key in col_infos.items():
            f.writelines(dictionary_template.replace("[comment]", escape(value)).replace("[name]", key))
            f.write("\n")
        f.write("\n")

def write_message(message):
    with codecs.open(table_dictionary_path, "a", "utf-8") as f:
        f.write(message + "\n")

def escape(value):
    chars = ["(", ")", "（", "）"]
    for char in chars:
        value = value.replace(char, "\\\\" + char)
    return value

# ==================================

for path, subdirs, files in os.walk(table_folder_path):
    for excel_name in files:
        table_name = re.sub(r".*_|.xlsx", "", excel_name)
        tab_infos = get_table_info(os.path.join(path, excel_name))
        write_dictionary(tab_infos)

write_message("//===common===")

# com_infos = {"検索項目": "SELECT", "取得項目": "SELECT", "検索テーブル": "FROM", "取得テーブル": "FROM", \
#              "検索条件": "WHERE", "取得条件": "WHERE", \
#              "：": ""}

# write_dictionary(com_infos)

print("finish")
