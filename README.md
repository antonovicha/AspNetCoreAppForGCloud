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
* Build Release of docker-compose project in Visual Studio
* Localhost: docker tag aspnetcoreapp:latest eu.gcr.io/pragmatic-byway-163819/aspnetcoreapp
* Localhost: gcloud docker -- push eu.gcr.io/pragmatic-byway-163819/aspnetcoreapp
* Create new Google Cloud container instance based on `Container-Optimized OS` image
* Configure container instance as follows: https://cloud.google.com/container-optimized-os/docs/how-to/run-container-instance#starting_a_docker_container_via_cloud-config

Custom metadata - user-data
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
* Run VM instance, it should pickup deployed image and run it
* Test that app is successfully deployed via `External Ip`/api/values

# .NET Core libs
## DI
### Castle Windsor
Not yet: https://github.com/castleproject/Windsor/issues/145

Alternative: https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/

Also Autofac & StructureMap
## ORM
### NHibernate
Not yet: https://nhibernate.jira.com/browse/NH-3807

Alternatives: http://stackoverflow.com/a/42503328
## Validation
### FluentValidation
Yes: https://github.com/JeremySkinner/FluentValidation

## Json support
### JSON.Net
Yes: https://www.nuget.org/packages/Newtonsoft.Json/

## Logging
### log4net
Yes: https://logging.apache.org/log4net/release/framework-support.html

## Testing
### NUnit
Yes
### RhinoMocks
Yes
# Other
* App config in JSON file, not in web.config: ???

# Usefull tools
## ApiTool
https://github.com/Microsoft/dotnet-apiport
Check compatability of .NET application with .NET Standard