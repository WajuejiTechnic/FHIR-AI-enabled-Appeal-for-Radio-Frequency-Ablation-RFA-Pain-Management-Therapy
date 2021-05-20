# Special Instructions

In order to build and run the application simply use the `docker-compose build` and `docker-compose up` commands
in the root directory. The client application is hosted at `http://localhost:3000`, and the server is hosted on 
`http://localhost:8080`. Generally speaking, there is no need to directly interact with the server, however it is
an option so that it can be used with any client, or even with no client at all.

If on the GT network, the client is hosted at `https://cs6440-s19-prj013.apps.hdap.gatech.edu/`, and the server
is hosted at the same endpoint using the `/api` route. For example, to get a list of all patients via the server's
REST Api, the endpoint would be `https://cs6440-s19-prj013.apps.hdap.gatech.edu/api/patient`.