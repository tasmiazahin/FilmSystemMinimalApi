# FilmSystemMinimalApi

## Create an REST API where user can GET/POST favourite movie links, genre, rating etc.

The goals of the project is to create a simple application which will create few api endpoints to get data about movies, persons and genres.
I have used .NET 6 minimal API and repository pattern. 


### Functionalities

* API endpoints (GET/POST) for all entities (Person, Genre. PersonChoice).
* Search functionlities.
* Pagination
* Swagger API documentation 
 

### Endpoints

#### GET /api/person

```
Request:

https://localhost:7026/api/person

Response:

[
  {
    "id": 1,
    "firstName": "Tasmia",
    "lastName": "Zahin",
    "emailAddress": "tasmiazahin@gmail.com",
    "personChoices": null
  },
  {
    "id": 2,
    "firstName": "Eric",
    "lastName": "Andersson",
    "emailAddress": "test@example.com",
    "personChoices": null
  }
  ...
]

```

#### POST /api/person

```
Request:

https://localhost:7026/api/person

Request body:

{
  "firstName": "test",
  "lastName": "user",
  "emailAddress": "test@example.com"
}

Response:

{
  "id": 7,
  "firstName": "test",
  "lastName": "user",
  "emailAddress": "test@example.com",
  "personChoices": null
}

```

#### GET /api/person/search

```
Request:

https://localhost:7026/api/person/search?searchtext=Andersson

Response:

[
  {
    "id": 2,
    "firstName": "Eric",
    "lastName": "Andersson",
    "emailAddress": "test@example.com",
    "personChoices": null
  },
  {
    "id": 5,
    "firstName": "Anna",
    "lastName": "Andersson",
    "emailAddress": "anna@example.com",
    "personChoices": null
  }
]

```

#### GET api/person/{pageNumber}

```
Request:

https://localhost:7026/api/person/1

Response: List of first 10 persons
For page 2, method will skip first 10 and take next 10 persons.

[
  {
    "id": 1,
    "firstName": "Tasmia",
    "lastName": "Zahin",
    "emailAddress": "tasmiazahin@gmail.com",
    "personChoices": null
  },
  {
    "id": 2,
    "firstName": "Eric",
    "lastName": "Andersson",
    "emailAddress": "test@example.com",
    "personChoices": null
  }
  ....
]

```


#### GET /api/genre

```
Request:

https://localhost:7026/api/genre

Response:

[
  {
    "id": 1,
    "title": "Romantic",
    "description": "Romantic movie"
  },
  {
    "id": 2,
    "title": "Horror",
    "description": "Horror movie"
  }
  ...
]

```

#### POST /api/genre

```
Request:

https://localhost:7026/api/genre

Request body:

{
    "title": "Thriller",
    "description": "Thriller movies"
}

Response:

{
  "id": 5,
  "title": "Thriller",
  "description": "Thriller movies"
}

```

#### GET /api/personchoice

```
Request:

https://localhost:7026/api/personchoice

Response:

[
  {
    "id": 1,
    "movieLink": "https://www.themoviedb.org/movie/603692-john-wick-chapter-4",
    "rating": 8,
    "personId": 1,
    "genreId": 3,
    "person": null,
    "genre": null
  },
  {
    "id": 2,
    "movieLink": "https://www.themoviedb.org/movie/76600-avatar-the-way-of-water",
    "rating": 9,
    "personId": 2,
    "genreId": 4,
    "person": null,
    "genre": null
  }
  ...
]

```

#### GET /api/personchoice/{personid}

```
Request:

https://localhost:7026/api/personchoice/{personid}?id=2

Response:

[
  {
    "id": 2,
    "movieLink": "https://www.themoviedb.org/movie/76600-avatar-the-way-of-water",
    "rating": 9,
    "personId": 2,
    "genreId": 4,
    "person": null,
    "genre": null
  }
  ...
]

```

#### GET /api/personchoice/genre/{personid}

```
Request:

https://localhost:7026/api/personchoice/genre/{personid}?id=2

Response: List of Genre (list of string)

[
  "Sci-fi",
  "Action"
]

```

#### GET /api/personchoice/movie/{personid}

```
Request:

https://localhost:7026/api/personchoice/movie/{personid}?id=2

Response: List of movie links to download (list of string)

[
  "https://www.themoviedb.org/movie/76600-avatar-the-way-of-water",
  "https://www.themoviedb.org/movie/677179-creed-iii"
]

```

#### POST /api/personChoice

```
Request:

https://localhost:7026/api/personChoice

Request body:

{
  "movieLink": "https://www.themoviedb.org/movie/638974-murder-mystery-2",
  "rating": 5,
  "personId": 3,
  "genreId": 5
}

Response:

{
  "id": 5,
  "movieLink": "https://www.themoviedb.org/movie/638974-murder-mystery-2",
  "rating": 5,
  "personId": 3,
  "genreId": 5,
  "person": null,
  "genre": null
}

```

