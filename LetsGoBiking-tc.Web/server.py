import http.server
import socketserver
PORT = 8009
Handler = http.server.SimpleHTTPRequestHandler

with socketserver.TCPServer(("", PORT), Handler) as httpd:
	print("Server launched at ", PORT)
	httpd.serve_forever()