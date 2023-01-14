from PIL import Image
from hzf.file import find_file

ff = find_file.FindFile(r"D:\E-Book\人物传记\bin\奥山かずさ\2022.03.14 【デジタル限定】奥山かずさ写真集「I LOVE SHORT CUT」")

files = ff.get_file_in_dir()

for f in files:
    pic = Image.open(f)
    # pic = pic.resize((int(pic.size[0] / 2), int(pic.size[1] / 2)), Image.Resampling.LANCZOS)
    pic = pic.convert('RGB')
    pic.save(f.replace("png", "jpg"), "JPEG", quality=100)
