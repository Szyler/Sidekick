```
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout localhost.key -out localhost.crt
openssl pkcs12 -info -in localhost.pfx
```
