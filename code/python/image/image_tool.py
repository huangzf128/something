import os, glob
from PIL import Image

PNG = "png"
JPG = "jpg"

class Image_Tool:

    def __init__(self, root_dir, out_dir):
        self.root_dir = root_dir
        self.out_dir = out_dir

    def converter(self, img_name, before, after):
        img = Image.open(os.path.join(self.root_dir, img_name))
        # RGBA(png)→RGB(jpg)へ変換
        img = img.convert('RGB')
        img.save(os.path.join(self.out_dir, img_name.replace(before, after)), "JPEG", quality=95)

    def crop(self):
        pass


if __name__ == '__main__':

    img_tools = Image_Tool(os.path.join(os.getcwd(), "01"), os.path.join(os.getcwd(), "01"))

    # .pngファイルをリストで取得する
    filepath_list = glob.glob(os.path.join(os.getcwd(), "01/*"))
    for filepath in filepath_list:
        # ファイルパスからファイル名を取得
        file_name = os.path.basename(filepath)
        img_tools.converter(file_name, PNG, JPG)
