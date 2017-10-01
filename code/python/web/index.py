import time
from selenium import webdriver
from selenium.webdriver.common.keys import Keys


class FetchPic:

    def __init__(self):
        self.driver = webdriver.Chrome()

    def fetch(self, url):
        self.driver.get(url)
        elem = self.driver.find_element_by_xpath("//article[@class='_mesn5']//a[@class='_1cr2e _epyes']")
        elem.send_keys(Keys.RETURN)
        self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
        body = self.driver.find_element_by_tag_name("Body")
        scrollHeight = 0
        while(int(body.get_attribute('scrollHeight')) > scrollHeight):
            scrollHeight = int(body.get_attribute('scrollHeight'))
            self.driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
            time.sleep(2)
            # print(body.get_attribute('scrollHeight'))

    def tearDown(self):
        self.driver.close()


fetch_pic = FetchPic()
fetch_pic.fetch("https://www.instagram.com/girleatworld/")
# fetch_pic.tearDown()
