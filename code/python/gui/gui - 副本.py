import os, fileinput, tkinter, datetime
import srteditor
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

# --------------- event ---------------------

def search():
    lines = search_file(os.path.join(rootPath, fileName), entry_keyword.get())
    result = ""
    for line, lineno in lines:
        result += (str(lineno) + "-----" + line)
    lbl_result_var.set(result)
    # messagebox.showinfo("Hello Python", line)

def update():
    target_file_path = os.path.join(rootPath, fileName)
    min = int(entry_min.get())
    sec = int(entry_sec.get())
    during = datetime.timedelta(minutes=min, seconds=sec)

    srt_editor = srteditor.SrtEditor()
    for line, new, lineno in srt_editor.inplace(target_file_path):
        if len(line.strip()) > 0 and lineno >= int(entry_lineno.get()):
            line = srt_editor.time_shift(line, during)
        new.write(line)
    print("done")

def delete():
    target_file_path = os.path.join(rootPath, fileName)
    del_lineno_str = int(entry_del_lineno_str.get())
    del_lineno_end = int(entry_del_lineno_end.get())

    srt_editor = srteditor.SrtEditor()
    for line, new, lineno in srt_editor.inplace(target_file_path):
        line = srt_editor.del_row((line, lineno), (del_lineno_str, del_lineno_end))
        if line is None:
            continue
        new.write(line)
    print("done")

# --------------- print ---------------------
top = tkinter.Tk()

# search
upperframe = tkinter.Frame(top)
upperframe.pack(side=tkinter.TOP, fill=tkinter.X)

entry_keyword = tkinter.Entry(upperframe, bd=5)
entry_keyword.pack(side=tkinter.LEFT)
btnSrch = tkinter.Button(upperframe, text="search", command=search)
btnSrch.pack(side=tkinter.LEFT)

# update
center_frame = tkinter.Frame(top)
center_frame.pack(side=tkinter.TOP, fill=tkinter.X)

entry_min = tkinter.Entry(center_frame)
entry_min.grid(row=0, column=0)
entry_sec = tkinter.Entry(center_frame)
entry_sec.grid(row=0, column=1)

entry_lineno = tkinter.Entry(center_frame, bd=5)
entry_lineno.grid(row=1, column=0)
btn_upd = tkinter.Button(center_frame, text="update", command=update)
btn_upd.grid(row=1, column=1)

# delete
entry_del_lineno_str = tkinter.Entry(center_frame)
entry_del_lineno_str.grid(row=2, column=0)
entry_del_lineno_end = tkinter.Entry(center_frame)
entry_del_lineno_end.grid(row=2, column=1)
btn_del = tkinter.Button(center_frame, text="delete", command=delete)
btn_del.grid(row=2, column=2)

# result
lower_frame = tkinter.Frame(top)
lower_frame.pack(side=tkinter.TOP, fill=tkinter.X)

lbl_result_var = tkinter.StringVar()
lbl_result = tkinter.Label(lower_frame, textvariable=lbl_result_var,
                           anchor=tkinter.W, justify=tkinter.LEFT, width=80, height=25)
lbl_result.pack(side=tkinter.BOTTOM)

entry_keyword.focus_set()
top.mainloop()
