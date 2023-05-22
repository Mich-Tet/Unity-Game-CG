import serial
import serial.tools.list_ports



s = serial.Serial()
s.baudrate = 9600
#s.port = 'COM2'
#s.open()

ports = serial.tools.list_ports.comports()
for port, desc, hwid in sorted(ports):
        print(f"{port}: {desc} [{hwid}]")
print(s)