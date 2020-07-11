# JsonLogParser

Simple parser application for json log files in the format of Serilog compact files.
So far very small functionality and error handling is not yet implemented.

Supported format based on [https://github.com/serilog/serilog-formatting-compact](https://github.com/serilog/serilog-formatting-compact)

## Usage

```bash
cat short.log  | ./JsonLogParser
```

Output

```bash
07/10/2020 21:21:59 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:21:59 Request finished in 2.416ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:04 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:04 Request finished in 0.1882ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:11 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:11 Request finished in 0.1924ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:14 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:14 Request finished in 0.1658ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:23 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:23 Request finished in 0.1702ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:24 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:24 Request finished in 0.3529ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:34 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca22a1cb
07/10/2020 21:22:34 Request finished in 0.1724ms 200 application/jsonEventId:791a596a
07/10/2020 21:22:35 Request starting HTTP/1.1 GET http://192.168.5.55:80/health  EventId:ca2
```
