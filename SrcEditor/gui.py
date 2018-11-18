import os, fileinput, tkinter, datetime
import srteditor, converter
from tkinter import messagebox

rootPath = os.path.join(os.getcwd(), "")
fileName = "Legal V EP01 720p HDTV x264 AAC-DoA.srt"

def search_file(target_file_path, target_text):
    lines = []
    with fileinput.FileInput(target_file_path, inplace=False, openhook=fileinput.hook_encoded("utf-8")) as file:
        for line in file:
            lines.append((line, file.lineno()))
            if len(lines) >= 20:
                lines.pop(0)
            if line.find(target_text) > 0:
                return lines
        return None

def get_shift_time():
    format = '%H:%M:%S'
    srt_time = converter.str_2_datetime(ent_srt_time.get(), format)
    video_time = converter.str_2_datetime(ent_video_time.get(), format)
    shift_time = video_time - srt_time
    return shift_time

# ============= event ===================
def search():
    lines = search_file(os.path.join(rootPath, fileName), ent_keyword.get())
    result = ""
    for line, lineno in lines:
        result += (str(lineno) + "-----" + line)
    lbl_result_var.set(result)
    # messagebox.showinfo("Hello Python", line)


def update():
    target_file_path = os.path.join(rootPath, fileName)
    during = get_shift_time()

    srt_editor = srteditor.SrtEditor()
    for line, new, lineno in srt_editor.inplace(target_file_path):
        if len(line.strip()) > 0 and lineno >= int(ent_lineno.get()):
            line = srt_editor.time_shift(line, during)
        new.write(line)
    print("done")


def delete():
    target_file_path = os.path.join(rootPath, fileName)
    del_lineno_str = int(ent_lineno_str.get())
    del_lineno_end = int(ent_lineno_end.get())

    srt_editor = srteditor.SrtEditor()
    for line, new, lineno in srt_editor.inplace(target_file_path):
        line = srt_editor.del_row((line, lineno), (del_lineno_str, del_lineno_end))
        if line is None:
            continue
        new.write(line)
    print("done")

# --------------- print ---------------------
# init
root = tkinter.Tk()
root.title("srt editor")

# ======= header =======
head = tkinter.Frame(root, borderwidth=2, relief="sunken", bg='yellow', padx=3, pady=3)
head.grid(column=0, row=0)

# title
lab_title = tkinter.Label(head, text="Srt Editor")
lab_title.grid(column=0, row=0, columnspan=5)

# search area
lab_keyword = tkinter.Label(head, text="Keyword")
ent_keyword = tkinter.Entry(head)
btnSrch = tkinter.Button(head, text="search", command=search, bg="red")

lab_keyword.grid(column=0, row=1, sticky=tkinter.W)
ent_keyword.grid(column=1, row=1, sticky=tkinter.W)
btnSrch.grid(column=2, row=1, columnspan=3, sticky=tkinter.E, pady=5, padx=15)

# update
lab_min = tkinter.Label(head, text="srt time:")
ent_srt_time = tkinter.Entry(head)
lab_sec = tkinter.Label(head, text="video time:")
ent_video_time = tkinter.Entry(head)

lab_lineno = tkinter.Label(head, text="lineno")
ent_lineno = tkinter.Entry(head)
btn_upd = tkinter.Button(head, text="update", command=update, bg="blue")

lab_min.grid(column=0, row=2, sticky=tkinter.W)
ent_srt_time.grid(column=1, row=2)
lab_sec.grid(column=2, row=2, sticky=tkinter.W, padx=5)
ent_video_time.grid(column=3, row=2)
lab_lineno.grid(column=0, row=3, sticky=tkinter.W)
ent_lineno.grid(column=1, row=3)
btn_upd.grid(column=2, row=3, columnspan=3, sticky=tkinter.E, pady=5, padx=15)

# delete
lab_lineno_str = tkinter.Label(head, text="lineno From")
ent_lineno_str = tkinter.Entry(head)
lab_lineno_end = tkinter.Label(head, text="To")
ent_lineno_end = tkinter.Entry(head)
btn_del = tkinter.Button(head, text="delete", command=delete)

lab_lineno_str.grid(column=0, row=4, sticky=tkinter.W)
ent_lineno_str.grid(column=1, row=4)
lab_lineno_end.grid(column=2, row=4, sticky=tkinter.W, padx=5)
ent_lineno_end.grid(column=3, row=4)
btn_del.grid(column=4, row=4, sticky=tkinter.E, pady=5, padx=15)

# ========= body =============
body = tkinter.Frame(root, borderwidth=2, relief="sunken", bg='blue', padx=3, pady=3)
body.grid(column=0, row=1)

# result
lbl_result_var = tkinter.StringVar()
lbl_result = tkinter.Label(body, textvariable=lbl_result_var,
                           anchor=tkinter.W, justify=tkinter.LEFT, width=80, height=25)
lbl_result.grid(column=0, row=0)

ent_keyword.focus_set()
root.mainloop()
