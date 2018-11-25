import tkinter, srteditor_event

class frm(object):

    def __init__(self):
        self.cache = {"src_lineno": []}
        self.bg_color = {"head": "#F5E04A"}

        self.create_control()
        self.layout()
        self.print()

    def layout(self):
        # ======= header =======
        self.head.grid(column=0, row=0)

        self.lab_title.grid(column=0, row=0, columnspan=5)

        # search area
        self.lab_keyword.grid(column=0, row=1, sticky=tkinter.W)
        self.ent_keyword.grid(column=1, row=1, sticky=tkinter.W)
        self.frm_srch_btn.grid(column=2, row=1, columnspan=3)
        self.btn_srch.pack(side="left", padx=5)
        self.btn_prev.pack(side="left", padx=5)
        self.btn_next.pack(side="left", padx=5)

        # update area
        self.lab_min.grid(column=0, row=2, sticky=tkinter.W)
        self.ent_srt_time.grid(column=1, row=2)
        self.lab_sec.grid(column=2, row=2, sticky=tkinter.W, padx=5)
        self.ent_video_time.grid(column=3, row=2)
        self.lab_lineno.grid(column=0, row=3, sticky=tkinter.W)
        self.ent_lineno.grid(column=1, row=3)
        self.btn_upd.grid(column=2, row=3, columnspan=3, sticky=tkinter.E, pady=5, padx=15)

        # delete area
        self.lab_lineno_str.grid(column=0, row=4, sticky=tkinter.W)
        self.ent_lineno_str.grid(column=1, row=4)
        self.lab_lineno_end.grid(column=2, row=4, sticky=tkinter.W, padx=5)
        self.ent_lineno_end.grid(column=3, row=4)
        self.btn_del.grid(column=4, row=4, sticky=tkinter.E, pady=5, padx=15)

        # ========= body =============
        self.body.grid(column=0, row=1)

        # result
        self.txt_src_rst.grid(column=0, row=0)

    def create_control(self):

        # init
        self.root = tkinter.Tk()
        self.root.title("srt editor")

        # ======= header =======
        self.head = tkinter.Frame(self.root, borderwidth=2, relief="sunken", bg=self.bg_color["head"], padx=3, pady=3)
        # title
        self.lab_title = tkinter.Label(self.head, text="Srt Editor")

        # search area
        self.lab_keyword = tkinter.Label(self.head, text="Keyword")
        self.ent_keyword = tkinter.Entry(self.head)
        self.frm_srch_btn = tkinter.Frame(self.head, bg=self.bg_color["head"])
        self.btn_srch = tkinter.Button(self.frm_srch_btn, text="search", command=self.search, bg="#1BD308")
        self.btn_prev = tkinter.Button(self.frm_srch_btn, text="prev", command=self.prev, bg="#CDF7A2")
        self.btn_next = tkinter.Button(self.frm_srch_btn, text="next", command=self.next, bg="#CDF7A2")

        # update area
        self.lab_min = tkinter.Label(self.head, text="srt time:")
        self.ent_srt_time = tkinter.Entry(self.head)
        self.lab_sec = tkinter.Label(self.head, text="video time:")
        self.ent_video_time = tkinter.Entry(self.head)

        self.lab_lineno = tkinter.Label(self.head, text="lineno")
        self.ent_lineno = tkinter.Entry(self.head)
        self.btn_upd = tkinter.Button(self.head, text="update", command=self.update, bg="blue")

        # delete area
        self.lab_lineno_str = tkinter.Label(self.head, text="lineno From")
        self.ent_lineno_str = tkinter.Entry(self.head)
        self.lab_lineno_end = tkinter.Label(self.head, text="To")
        self.ent_lineno_end = tkinter.Entry(self.head)
        self.btn_del = tkinter.Button(self.head, text="delete", command=self.delete)

        # ========= body =============
        self.body = tkinter.Frame(self.root, borderwidth=2, relief="sunken", bg='blue', padx=3, pady=3)
        # result
        self.txt_src_rst = tkinter.Text(self.body, width=75, height=25)

    def print(self):
        self.ent_keyword.focus_set()
        self.root.mainloop()

    def search(self):
        srteditor_event.search(self)

    def prev(self):
        srteditor_event.prev(self)

    def next(self):
        srteditor_event.next(self)

    def update(self):
        srteditor_event.update(self)

    def delete(self):
        pass

if __name__ == "__main__":
    g = frm()
