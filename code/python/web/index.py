import time, getResource
from selenium import webdriver
from selenium.webdriver.common.keys import Keys


class FetchPic:

    def __init__(self):
        self.driver = webdriver.Chrome()

    def scroll(self):
        # self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
        body = self.driver.find_element_by_tag_name("Body")
        scrollHeight = 0
        while(int(body.get_attribute('scrollHeight')) > scrollHeight):
            scrollHeight = int(body.get_attribute('scrollHeight'))
            self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
            time.sleep(2)
            # print(body.get_attribute('scrollHeight'))

    def parser_for_imgurls(self):
        img_urls = []
        for img_obj in self.driver.find_elements_by_xpath("//span[@id='react-root']//div[@class='_cmdpi']//img"):
            img_urls.append(img_obj.get_attribute("src"))
        return img_urls

    def get_img(self, img_urls):
        getRes = getResource.GetResource("pic")
        for url in img_urls:
            getRes.get(url)

    def fetch(self, url):
        self.driver.get(url)
        elem = self.driver.find_element_by_xpath("//article[@class='_mesn5']//a[@class='_1cr2e _epyes']")
        elem.send_keys(Keys.RETURN)

        # self.scroll()

        img_urls = self.parser_for_imgurls()
        self.get_img(img_urls)

    def tearDown(self):
        self.driver.close()


fetch_pic = FetchPic()
fetch_pic.fetch("https://www.instagram.com/girleatworld/")
fetch_pic.tearDown()
