# LindowsX509Helper

## Command Line Usage:

### Linux:
#### Add:
```
dotnet LindowsX509Helper.dll --add "./certificateFileName"
```
Or:
```
dotnet LindowsX509Helper.dll -a "./certificateFileName"
```
#### Remove:
```
dotnet LindowsX509Helper.dll --remove "AwesomeYuer.Microshaoft.com"
```
Or:
```
dotnet LindowsX509Helper.dll -r "AwesomeYuer.Microshaoft.com"
```

### Windows:
#### Add:
```
LindowsX509Helper --add ".\certificateFileName"
```
Or:
```
LindowsX509Helper -a ".\certificateFileName"
```
#### Remove:
```
LindowsX509Helper --remove "AwesomeYuer.Microshaoft.com"
```
Or:
```
LindowsX509Helper -r "AwesomeYuer.Microshaoft.com"
```

## X509Store Location:

### Linux:
```
~/.dotnet/corefx/cryptography/x509stores/my/
```

### Windows:
```
certmgr.msc
```
