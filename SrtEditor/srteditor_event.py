from hzf.date import date_util
import os, fileinput, tkinter
import srteditor
from tkinter import messagebox

rootPath = os.path.join(os.getcwd(), "")
fileName = "Legal V EP01 720p HDTV x264 AAC-DoA.srt"

def search_file(target_file_path, target_text, str_lineno=0):
    lines = []
    with fileinput.FileInput(target_file_path, inplace=False, openhook=fileinput.hook_encoded("utf-8")) as file:
        for line in file:
            if (file.filelineno() <= str_lineno):
                continue
            lines.append((line, file.filelineno()))
            if len(lines) >= 20:
                lines.pop(0)
            if line.find(target_text) >= 0:
                return lines
        return None

def get_shift_time(str_time, end_time):
    format = '%H:%M:%S'
    srt_time = date_util.str_2_datetime(str_time, format)
    video_time = date_util.str_2_datetime(end_time, format)
    shift_time = video_time - srt_time
    return shift_time

# ============= event function ===================
def search(frm):
    frm.cache["src_lineno"] = []
    next(frm)

def prev(frm):
    try:
        frm.cache["src_lineno"].pop()
        frm.cache["src_lineno"].pop()
    except:
        pass
    next(frm)
    
def next(frm):
    frm.txt_src_rst.config(state="normal")
    lines = search_file(os.path.join(rootPath, fileName), frm.ent_keyword.get(), 
                        frm.cache["src_lineno"][-1] if frm.cache["src_lineno"] else 0)
    if lines is None:
        return
    result = ""
    for line, lineno in lines:
        result += (str(lineno) + "-----" + line)
    frm.txt_src_rst.delete('0.1', tkinter.END)
    frm.txt_src_rst.insert(tkinter.END, result)
    frm.txt_src_rst.config(state="disabled")
    frm.cache["src_lineno"].append(lineno)
    
    # messagebox.showinfo("Hello Python", line)

def update(frm):
    target_file_path = os.path.join(rootPath, fileName)
    during = get_shift_time(frm.ent_srt_time.get(), frm.ent_video_time.get())

    srt_editor = srteditor.SrtEditor()
    for line, new, lineno in srt_editor.inplace(target_file_path):
        if len(line.strip()) > 0 and lineno >= int(frm.ent_lineno.get()):
            line = srt_editor.time_shift(line, during)
        new.write(line)
    print("done")


# def delete():
#     target_file_path = os.path.join(rootPath, fileName)
#     del_lineno_str = int(ent_lineno_str.get())
#     del_lineno_end = int(ent_lineno_end.get())

#     srt_editor = srteditor.SrtEditor()
#     for line, new, lineno in srt_editor.inplace(target_file_path):
#         line = srt_editor.del_row((line, lineno), (del_lineno_str, del_lineno_end))
#         if line is None:
#             continue
#         new.write(line)
#     print("done")
