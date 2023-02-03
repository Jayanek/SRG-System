
# Surge Global Assignment




## Run Locally

Clone the project

```bash
  git clone https://github.com/Jayanek/SRG-System.git my-project
```

Go to the project directory

```bash
  cd my-project
```

Open appsettings.json and add database connection info

```bash
  "CosmosDbSettings": {
  "AccountURL": "",
  "AuthKey": "",
  "DatabaseId": "",
  "ContainerName": ""
},
"MySQLConnection": "{ADD_MYSQL DB CONNECTION STRING}"
```

Start the server

```bash
  dotnet run
```


