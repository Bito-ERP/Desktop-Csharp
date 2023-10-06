# BitoDesktop
## Auth
#
### Get all [usernames](https://github.com/Bito-ERP/Desktop-Csharp/blob/data/BitoDesktop.Service/http/AuthApi.cs#L12)
### Request
```
phone_number
password
```
#
### [Login](https://github.com/Bito-ERP/Desktop-Csharp/blob/data/BitoDesktop.Service/http/AuthApi.cs#L15C12-L15C12)
### Header //username is required from this point
```
username: [the username which is selected by user]
```
### Request
```
phone_number
password
```
### Response
``You get a string token``
#
### [Get Device Page](https://github.com/Bito-ERP/Desktop-Csharp/blob/data/BitoDesktop.Service/http/DeviceApit.cs#L15C12-L15C12)
### Request
```
limit
page
imei // unique identifier of device, MAC Address for instance. 
```
#
### [Device Brone](https://github.com/Bito-ERP/Desktop-Csharp/blob/data/BitoDesktop.Service/http/DeviceApit.cs#L18)
### Request
```
_id           // _id of selected device
device_name   // name of selected device
imei // unique identifier of device, MAC Address for instance. 
```
### Note
``You will send '_id' of a device as 'pos_id' in the header, from this point it is required``