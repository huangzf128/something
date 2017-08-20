import os, fileinput, tkinter, codecs, modify_time
from tkinter import messagebox

rootPath = os.path.join(os.getcwd(), "")
fileName = "Kurokawa no Techou ep01 (848x480 x264).srt"

line_info = []

def add_line_info(ele):
    line_info.append(ele)
    if len(line_info) > 10:
        line_info.pop(0)

def get_line_info():
    return line_info

def search_file(target_file_path, target_text):
    with fileinput.FileInput(target_file_path, inplace=False, openhook=fileinput.hook_encoded("utf-8")) as file:
        for line in file:
            if len(line.strip()) == 0:
                continue
            add_line_info((line, file.lineno()))
            if line.find(target_text) > 0:
                return get_line_info()
        return None

top = tkinter.Tk()
def search():
    lines = search_file(os.path.join(rootPath, fileName), entry_keyword.get())
    result = ""
    for line, lineno in lines:
        result += (str(lineno) + "-----" + line)
    lbl_result_var.set(result)
    #messagebox.showinfo("Hello Python", line)

def inplace(orig_path, encoding='utf-8'):
    """Modify a file in-place, with a consistent encoding."""
    new_path = orig_path + '.modified'
    lineno = 0
    with codecs.open(orig_path, encoding=encoding) as orig:
        with codecs.open(new_path, 'wb', encoding=encoding) as new:
            for line in orig:
                lineno += 1
                yield line, new, lineno
    os.rename(orig_path, orig_path + ".bk")
    os.rename(new_path, orig_path)

def update():
    target_file_path = os.path.join(rootPath, fileName)
    min = entry_min.get()
    sec = entry_sec.get()
    for line, new, lineno in inplace(target_file_path):
        if len(line.strip()) > 0 and lineno >= int(entry_lineno.get()):
            line = modify_time.process_line(line, int(min), int(sec))
        new.write(line)
    print("done")

# --------------- print ---------------------

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

entry_min = tkinter.Entry(center_frame, bd=5)
entry_min.pack(side=tkinter.LEFT)
entry_sec = tkinter.Entry(center_frame, bd=5)
entry_sec.pack(side=tkinter.LEFT)

entry_lineno = tkinter.Entry(center_frame, bd=5)
entry_lineno.pack(side=tkinter.LEFT)
btn_upd = tkinter.Button(center_frame, text="update", command=update)
btn_upd.pack(side=tkinter.RIGHT)

# result
lower_frame = tkinter.Frame(top)
lower_frame.pack(side=tkinter.TOP, fill=tkinter.X)

lbl_result_var = tkinter.StringVar()
lbl_result = tkinter.Label(lower_frame, textvariable=lbl_result_var,
                           anchor=tkinter.W, justify=tkinter.LEFT, width=80, height=15)
lbl_result.pack(side=tkinter.BOTTOM)

entry_keyword.focus_set()
top.mainloop()
