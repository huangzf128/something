import os, glob
from PIL import Image

PNG = "png"
JPG = "jpg"

class Image_Tool:

    def __init__(self, root_dir, out_dir):
        self.root_dir = root_dir
        self.out_dir = out_dir

        if not os.path.exists(self.out_dir):
            os.makedirs(self.out_dir)

    def converter(self, img_name, to_type):
        img = Image.open(os.path.join(self.root_dir, img_name))

        if (to_type == JPG):
            # RGBA(png)→RGB(jpg)へ変換
            img = img.convert('RGB')
            img.save(os.path.join(self.out_dir, os.path.splitext(img_name)[0] + ".jpg"), "JPEG", quality=95)

    def crop(self, img_name):
        img = Image.open(os.path.join(self.out_dir, img_name))
        img = img.crop((260, 0, img.size[0] - 260, img.size[1]))
        img.save(os.path.join(self.out_dir, img_name), "JPEG", quality=95)


if __name__ == '__main__':

    for i in range(1, 4):
        no = str(i).zfill(1)
        out_dir = os.path.join(os.getcwd(), "output/" + no)
        img_tools = Image_Tool(os.path.join(os.getcwd(), no), out_dir)
        img_tools_crop = Image_Tool(out_dir, out_dir)

        # .pngファイルをリストで取得する
        filepath_list = glob.glob(os.path.join(os.getcwd(), no + "/*.png"))
        for filepath in filepath_list:
            # ファイルパスからファイル名を取得
            file_name = os.path.basename(filepath)
            img_tools.converter(file_name, JPG)
            img_tools_crop.crop(file_name.replace(PNG, JPG))
