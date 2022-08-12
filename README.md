# dotNetLindowsX509Helper

## Command Line Usage:

### Linux:
#### Add:
```
dotnet dotNetLindowsX509Helper.dll --add "./certificateFileName"
```
Or:
```
dotnet dotNetLindowsX509Helper.dll -a "./certificateFileName"
```
#### Remove:
```
dotnet dotNetLindowsX509Helper.dll --remove "AwesomeYuer.Microshaoft.com"
```
Or:
```
dotnet dotNetLindowsX509Helper.dll -r "AwesomeYuer.Microshaoft.com"
```

### Windows:
#### Add:
```
dotNetLindowsX509Helper --add ".\certificateFileName"
```
Or:
```
dotNetLindowsX509Helper -a ".\certificateFileName"
```
#### Remove:
```
dotNetLindowsX509Helper --remove "AwesomeYuer.Microshaoft.com"
```
Or:
```
dotNetLindowsX509Helper -r "AwesomeYuer.Microshaoft.com"
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
