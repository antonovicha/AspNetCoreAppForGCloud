Things to test to ensure that they are here and working (or not).

# Visual Studio 2017
## Debug
### In container
Yes
### Outside of container
Yes

## Google Cloud
### Deploy
* Install https://cloud.google.com/sdk/
* Localhost: docker tag aspnetcoreapp:latest eu.gcr.io/pragmatic-byway-163819/aspnetcoreapp
* Localhost: gcloud docker -- push eu.gcr.io/pragmatic-byway-163819/aspnetcoreapp
* Configure container instance as follows: https://cloud.google.com/container-optimized-os/docs/how-to/run-container-instance#starting_a_docker_container_via_cloud-config
TODO


# .NET Core libs
## DI
### Castle Windsor
TODO
## ORM
### NHibernate
TODO
## Validation
### FluentValidation
TODO

## Json support
### JSON.Net
TODO
May be native?

# Other
* App config in JSON file, not in web.config: ???