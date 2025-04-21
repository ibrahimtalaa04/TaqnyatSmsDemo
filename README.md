# TaqnyatSmsDemo

This is a minimal .NET console application that demonstrates how to send SMS messages using the [Taqnyat SMS API](https://taqnyat.sa/).

It's intended as a quick test client for developers who want to try out Taqnyat before integrating it into their application.

---

## 🚀 Features

- ✅ Send SMS via Taqnyat API
- 🔐 Loads sensitive config (token, sender) from `appsettings.json`
- 💬 Prompts user for recipient number and message content at runtime
- 📦 Built with .NET 8 (can work with .NET 6+)

---

## 🛠️ Setup Instructions

### 1. Clone the repo
```bash
git clone https://github.com/ibrahimtalaa04/TaqnyatSmsDemo.git
cd TaqnyatSmsDemo
```

### 2. Install dependencies
This project uses the Microsoft.Extensions.Configuration libraries.
```
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
```
### 3. Update your appsettings.json
Create a file named appsettings.json in the project root:
```
{
  "SmsSettings": {
    "Token": "YOUR_TAQNYAT_TOKEN",
    "Sender": "YOUR_SENDER_NAME"
  }
}
```
⚠️ Never share your token publicly. Add appsettings.json to .gitignore.

### ▶️ Run the App

```
dotnet run
```
You’ll be prompted to enter the recipient’s number and the message content.

### 📷 Sample Output
```
Enter recipient phone number (e.g. +9665XXXXXXXX): +966512345678
Enter message to send: Hello from Ibrahim 🚀

📤 Sending SMS...
✅ Status Code: OK
📩 Response:
{
  "messageId": "abc123",
  "status": "queued",
  ...
}
```

### 📄 License
This project is released under the MIT License.
Feel free to use or contribute!

### 🤝 Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

### 📬 Contact

Created with ❤️ by Ibrahim
For questions or support, feel free to open an issue or message me.
