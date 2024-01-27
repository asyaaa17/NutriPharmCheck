import requests
from bs4 import BeautifulSoup
import re
import time
import pandas as pd
import random

session = requests.Session()  # Использование сессии для запросов

def make_request(url, headers, max_retries=5, initial_delay=20):
    delay = initial_delay
    for attempt in range(max_retries):
        response = session.get(url, headers=headers)  # Использование сессии
        if response.status_code == 200:
            return response
        elif response.status_code == 429:
            print(f"Ошибка 429: Слишком много запросов. Повторная попытка через {delay} секунд.")
            time.sleep(delay)
            delay = min(delay * 2, 600)  # Ограничение максимальной задержки
        else:
            print(f"Ошибка запроса: статус {response.status_code}")
            return None
    return None

# Вместо фиксированной паузы используйте случайную задержку
time.sleep(random.uniform(1, 3))

def scrape_product_details(product_url):
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3'
    }
    response = make_request(product_url, headers)
    if not response:
        return None

    soup = BeautifulSoup(response.content, 'html.parser')
    text = soup.get_text(strip=True)
    pattern = 'Способ применения.*?Действие на организм(.*?)[.!?]'
    match = re.search(pattern, text)
    if match:
        action_text = match.group(1).strip()
        return action_text

    return "Информация о действии на организм не найдена"

def extract_additional_info(url):
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3'
    }
    response = make_request(url, headers)
    if not response:
        return 'Ошибка при запросе к странице.'

    soup = BeautifulSoup(response.content, 'html.parser')
    text = soup.get_text(strip=True)
    pattern = 'ДаНет(.*?)Противопоказания:'
    match = re.search(pattern, text, re.DOTALL)
    if match:
        return match.group(1).strip()
    else:
        return 'Текст между "ДаНет" и "Противопоказания:" не найден.'

def extract_contraindications(url):
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3'
    }
    response = make_request(url, headers)
    if not response:
        return 'Ошибка при запросе к странице.'

    soup = BeautifulSoup(response.content, 'html.parser')
    text = soup.get_text(strip=True)
    pattern = 'Противопоказания:(.*?)Условия хранения препарата'
    match = re.search(pattern, text, re.DOTALL)
    if match:
        return match.group(1).strip()
    else:
        return 'Текст между "Противопоказания:" и "Условия хранения препарата" не найден.'

def scrape_names_and_urls_from_page(url):
    headers = {
        'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3'
    }
    response = make_request(url, headers)
    if not response:
        return []

    soup = BeautifulSoup(response.content, 'html.parser')
    products = []
    table = soup.find('table', id='baa__tradenames')
    if table:
        for row in table.find_all('tr'):
            name_tag = row.find('td')
            if name_tag and name_tag.a:
                name = name_tag.a.text.strip()
                product_url = name_tag.a['href']
                products.append((name, product_url))

    return products

base_url = 'https://www.rlsnet.ru/baa/pharm-groups/drugie-bady-4?page='
all_products = []

for page in range(26, 100):
    print(f"Обработка страницы {page}")
    url = base_url + str(page)
    products = scrape_names_and_urls_from_page(url)
    for name, product_url in products:
        effect = scrape_product_details(product_url)
        additional_info = extract_additional_info(product_url)
        contraindications = extract_contraindications(product_url)
        all_products.append((name, product_url, effect, additional_info, contraindications))
        time.sleep(1)  # Замедление запросов для избежания ошибки 429

# Вывод результатов
for name, product_url, effect, additional_info, contraindications in all_products:
    print(f"{name}: {product_url}, Действие на организм: {effect}, Дополнительная информация: {additional_info}, Противопоказания: {contraindications}")


df = pd.DataFrame(all_products, columns=["Название", "Ссылка", "Действие на организм", "Дополнительная информация", "Противопоказания"])


df.to_csv("products_info1.csv", index=False, encoding='utf-8-sig')


df.to_excel("products_info1.xlsx", index=False)
