from bs4 import BeautifulSoup
import requests
import re
import pandas as pd

url = 'http://www.imdb.com/chart/top'
response = requests.get(url)
soup = BeautifulSoup(response.text, "html.parser")
movies = soup.select('td.titleColumn')
crew = [a.attrs.get('title') for a in soup.select('td.titleColumn a')]
rate = [b.attrs.get('data-value') for b in soup.select('td.posterColumn span[name=ir]')]
MovieList = []
for index in range(0, len(movies)):
    movie_string = movies[index].get_text()
    movie = (' '.join(movie_string.split()).replace('.', ''))
    movie_title = movie[len(str(index)) + 1:-7]
    year = re.search('\((.*?)\)', movie_string).group(1)
    place = movie[:len(str(index)) - (len(movie))]
    data = {"place": place, "movie_title": movie_title, "rate": rate[index], "year": year,
            "star_cast": crew[index], }
    MovieList.append(data)

# for movie in MovieList:
#     print(movie['place'], '-', movie['movie_title'], '(' + movie['year'] +
#           ') -', 'Starring:', movie['star_cast'], movie['rate'])

df = pd.DataFrame(MovieList)
df.to_csv('imdb_top_250_movies.csv', index=False)