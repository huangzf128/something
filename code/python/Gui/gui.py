import os, fileinput, tkinter
from tkinter import messagebox

rootPath = os.path.join(os.getcwd(), "")
fileName = "Kurokawa no Techou ep01.srt"

def search_file(target_file_path, target_text):
    with fileinput.FileInput(target_file_path, inplace=False, openhook=fileinput.hook_encoded("utf-8")) as file:
        for line in file:
            if line.find(target_text) > 0:
                return line
        return None

top = tkinter.Tk()
def search():
    line = search_file(os.path.join(rootPath, fileName), entry_keyword.get())
    lab_result_var.set(line)
    #messagebox.showinfo("Hello Python", line)

# --------------- print ---------------------

upperframe = tkinter.Frame(top)
upperframe.pack(side=tkinter.TOP)

btnSrch = tkinter.Button(upperframe, text="search", command=search)
btnSrch.pack(side=tkinter.RIGHT)

entry_keyword = tkinter.Entry(upperframe, bd=5)
entry_keyword.pack(side=tkinter.LEFT)

lab_result_var = tkinter.StringVar()
lab_result = tkinter.Label(top, textvariable=lab_result_var, width=20, height=5)
lab_result.pack(side=tkinter.BOTTOM)

top.mainloop()
