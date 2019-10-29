# Globfs

A docker image which provides file search using globbing patterns.

## Getting Started

These instructions will cover usage information for the globfs docker container.

### Prerequisities

In order to run this container you'll need docker installed.

* [Windows](https://docs.docker.com/windows/started)
* [OS X](https://docs.docker.com/mac/started/)
* [Linux](https://docs.docker.com/linux/started/)

### Usage

#### Container Parameters

Mount the root search directory

```shell
docker run --rm -it -v /data/:/data atzedent/globfs "/data/**/*.jpg"
```

Use a placeholder for system directories and use awk to replace the result

```shell
docker run --rm -it -v /var/log/:/SEARCHDIR atzedent/globfs "/SEARCHDIR/**/*.log" | awk 'BEGIN { FS = "/SEARCHDIR/" } ; {print "/var/log/"$2}'
```


## Built With

* [C#](https://github.com/dotnet/csharplang)
* [Globkit](https://github.com/atzedent/globkit)

## Find Us

* [GitHub](https://github.com/atzedent/globfs)
* [Dockerhub](https://hub.docker.com/r/atzedent/globfs)

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the 
[tags on this repository](https://github.com/atzendent/globfs/tags). 

## Authors

* **Matthias Hurrle** - *Initial work*

See also the list of [contributors](https://github.com/atzedent/globfs/contributors) who 
participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
