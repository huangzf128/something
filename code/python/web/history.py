import time, getResource, os, time
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.chrome.options import Options

class FetchPic:

    def __init__(self):
        chrome_options = Options()
        chrome_options.add_argument("--kiosk")
        self.driver = webdriver.Chrome(chrome_options=chrome_options)


        # self.driver = webdriver.Chrome()
        # self.driver.set_window_size(4000, 4000)

        root = "F:\\repo\\something\\code\\python\\web\\output\\"
        folder = "jphistory\\"
        self.save_dir = root + folder
        # self.driver.set_window_size(1680, 1000)

    def scroll(self):
        # self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
        body = self.driver.find_element_by_tag_name("Body")
        scrollHeight = 0
        while(int(body.get_attribute('scrollHeight')) > scrollHeight):
            scrollHeight = int(body.get_attribute('scrollHeight'))
            self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
            time.sleep(2)
            # print(body.get_attribute('scrollHeight'))

    def change_page(self):
        elem = self.driver.find_element_by_xpath("//div[@id='tap_left_area']") 
        elem.click()

    def get_preface(self, pages):

        for no in pages:
            self.change_page()
            time.sleep(2)
            self.driver.save_screenshot(self.save_dir + str(no) + ".png")
            

    def fetch(self, url):
        self.url = url
        self.driver.get(self.url)
        time.sleep(10)
        self.driver.save_screenshot(self.save_dir + "cover.png")

        self.get_preface(list(range(1, 3)))
        
        # self.scroll()
        # img_urls = self.parser_for_imgurls()
        # self.get_img(img_urls)

    def tearDown(self):
        self.driver.close()

os.environ['PATH'] += ';F:\\repo\\something\\code\\python\\web;'

fetch_pic = FetchPic()
url = "https://kids-km3.shogakukan.co.jp/books/nichireki01"
fetch_pic.fetch(url)
fetch_pic.tearDown()
exit()