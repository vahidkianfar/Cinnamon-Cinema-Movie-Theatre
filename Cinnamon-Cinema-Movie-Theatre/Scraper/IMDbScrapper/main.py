from bs4 import BeautifulSoup
import requests
import re
import pandas as pd

url = 'http://www.imdb.com/chart/top'
response = requests.get(url)
soup = BeautifulSoup(response.text, "html.parser")
movies = soup.select('td.titleColumn')
casts = [cast.attrs.get('title') for cast in soup.select('td.titleColumn a')]
rate = [rating.attrs.get('data-value') for rating in soup.select('td.posterColumn span[name=ir]')]

MovieList = []

for index in range(0, len(movies)):
    movie_string = movies[index].get_text()
    movie = (' '.join(movie_string.split()).replace('.', ''))
    movie_title = movie[len(str(index)) + 1:-7]
    year = re.search('\((.*?)\)', movie_string).group(1)
    rank = movie[:len(str(index)) - (len(movie))]
    data = {"place": rank, "movie_title": movie_title, "rate": rate[index], "year": year,
            "star_cast": casts[index], }
    MovieList.append(data)


df = pd.DataFrame(MovieList)
df.to_csv('imdb_top_250_movies.csv', index=False)
