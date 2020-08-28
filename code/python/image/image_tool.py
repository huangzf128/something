import os, glob, re
from PIL import Image

PNG = "png"
JPG = "jpg"

class Image_Tool:

    def load(self, img_path):
        self.img = Image.open(img_path)

    def save_jpg(self, dir, img_name):
        if not os.path.exists(dir):
            os.makedirs(dir)

        self.img.save(os.path.join(dir, img_name), "JPEG", quality=95)

    def converter(self, to_type):
        if (to_type == JPG):
            # RGBA(png)→RGB(jpg)へ変換
            self.img = self.img.convert('RGB')

    def crop(self):
        self.img = self.img.crop((260, 0, self.img.size[0] - 260, self.img.size[1]))


if __name__ == '__main__':

    img = Image_Tool()

    for i in range(1, 2):
        no = str(i).zfill(1)
        out_dir = os.path.join(os.getcwd(), "output/" + no)

        # .pngファイルをリストで取得する
        filepath_list = glob.glob(os.path.join(os.getcwd(), no + "/*.png"))
        for filepath in filepath_list:
            img.load(filepath)
            img.converter(JPG)
            img.crop()
            file_name = os.path.basename(filepath)
            img.save_jpg(out_dir, re.sub(PNG, JPG, file_name, flags=re.IGNORECASE))
