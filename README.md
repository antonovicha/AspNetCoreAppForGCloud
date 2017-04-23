# Scope of this project
* Find out how to create & deploy ASP .NET Core application into Google Cloud (container engine).
* Look into essential libraries from .NET world: are they available for .NET Core? Is there is replacements?

# Used tools
* Visual Studio 2017 Community edition
* Docker for Windows
* Virtual Box
* Google Cloud SDK

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
Custom metadata
user-data
```sh
#cloud-configs

users:
- name: cloudservice
  uid: 2000

write_files:
- path: /etc/systemd/system/cloudservice.service
  permissions: 0644
  owner: root
  content: |
    [Unit]
    Description=Start a sample Asp NET Core docker container

    [Service]
    Environment="HOME=/home/cloudservice"
    ExecStartPre=/usr/share/google/dockercfg_update.sh
    ExecStart=/usr/bin/docker run --rm -p 80:80 --name=mycloudservice eu.gcr.io/pragmatic-byway-163819/aspnetcoreapp:latest /bin/sleep 3600
    ExecStop=/usr/bin/docker stop mycloudservice
    ExecStopPost=/usr/bin/docker rm mycloudservice

runcmd:
- systemctl daemon-reload
- sleep 5
- systemctl start cloudservice.service
```

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

## Logging
### log4net
TODO

# Other
* App config in JSON file, not in web.config: ???