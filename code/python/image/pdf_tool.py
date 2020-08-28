import os, glob
from fpdf import FPDF

class Pdf_Tool:

    def __init__(self, format):
        self.pdf = FPDF(format=format)

    def save(self, dir, pdf_name):
        if not os.path.exists(dir):
            os.makedirs(dir)

        self.pdf.output(os.path.join(dir, pdf_name), "F")

    def create(self, img_path_list, dimen):
        for img_path in img_path_list:
            self.pdf.add_page()
            self.pdf.image(img_path, dimen[0], dimen[1], dimen[2], dimen[3])


if __name__ == "__main__":

    root = os.path.join(os.getcwd(), "output")
    for i in range(1, 2):
        no = str(i).zfill(1)
        filepath_list = glob.glob(os.path.join(root, no + "/*.jpg"))
        pdf = Pdf_Tool((2040, 1512))
        pdf.create(filepath_list, (0, 0, 2040, 1512))
        pdf.save(os.path.join(root, no), no + ".pdf")
