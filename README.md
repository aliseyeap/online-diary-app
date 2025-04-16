# 📓 Online Diary Web Application

This is a secure Online Diary Web Application developed using **ASP.NET Core MVC (Clean Architecture)** and **SQL Server**, designed for users to safely record, manage, and store personal diary entries with strong privacy protection.

---

## 🚀 Features

### 🔐 Authentication & Security
- User registration and login
- Email verification (expires in 15 minutes)
- reCAPTCHA protection
- Two-Factor Authentication (OTP via email)
- Limit login attempts (lockout after 3 failures)
- Session auto-logout after 15 minutes of inactivity
- Secure password hashing using PBKDF2 with HMAC-SHA256

### 📖 Diary Management
- Add, edit, delete diary entries
- View personal diaries in a secure space
- Diary content encrypted with AEAD_AES_256_CBC_HMAC_SHA_256

### 🔐 Password & Account Management
- Strong password policy enforced
- Password masking on all fields
- Forgot password with email reset link
- Change password (with current password verification)

---

## 🧰 Tech Stack

- **Framework:** ASP.NET Core MVC (Clean Architecture)
- **Backend:** .NET 6/7 with Entity Framework Core
- **Frontend:** Razor Views (HTML, CSS)
- **Database:** SQL Server (via SQL Server Object Explorer)
- **Security:** reCAPTCHA, SHA-256, PBKDF2, OTP, Session Timeout

---

## 💻 Getting Started

Follow the steps below to run the Online Diary Web App on your local environment.

### 1. Clone the Repository
```bash
git clone https://github.com/aliseyeap/online-diary-app.git
```
### 2. Set Up the Database
- Open Visual Studio.
- Go to SQL Server Object Explorer.
- Right-click (localdb)\MSSQLLocalDB > Add New Database.
- Name the database:
```bash
OnlineDiaryDB
```
- Run migrations or update database using **Package Manager Console**:
```bash
Update-Database
```

### 3. Configure Database Connection
- In appsettings.json:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=OnlineDiaryDB;Trusted_Connection=True;"
}
```

### 4. Run the App
- Press F5 or click Start Debugging in Visual Studio.
- The app will open in your browser.

---
## 📧 Email Service (SendGrid)
The application uses SendGrid to send:
- Email verification links
- One-Time Passwords (OTP)
- Password reset emails

To enable SendGrid:
### 1. Get a SendGrid API Key
- Sign up at https://sendgrid.com
- Go to Settings > API Keys
- Click Create API Key and copy the key

### 2. Store the API Key Securely
- Use the .NET User Secrets Manager during development:
```bash
dotnet user-secrets set "SendGridKey" "your-sendgrid-api-key"
```

### 3. Configuration Class
- Ensure you have a class to store the API key:
```bash
public class AuthMessageSenderOptions
{
    public string SendGridKey { get; set; }
}
```

### 4. Usage
- The EmailSender service uses this API key to send emails:
```bash
await _emailSender.SendEmailAsync(user.Email, "Subject", "Message");
```
- SendGrid integration can be found in
```bash
OnlineDiary/Services/EmailSender.cs
```

---
## 📷 Screenshots

### 👤 User Interface
#### 🏠 Homepage (Before Login)
<img src="https://github.com/user-attachments/assets/df6929ff-61c3-4b02-9991-2dbdd24d683c" width="400"/>

#### 🔐 Login with reCAPTCHA
<img src="https://github.com/user-attachments/assets/bc4e1d32-7c0c-4b1e-aba5-f70b3f6c860c" width="400"/>

#### 📩 OTP Input
<img src="https://github.com/user-attachments/assets/03691b10-c2aa-4950-b957-63d5d144fa62" width="400"/>

#### 📖 My Diary Dashboard
<img src="https://github.com/user-attachments/assets/ddd7fbf8-27b8-42c8-99cc-a420717f08f5" width="400"/>

#### 📝 Add New Diary
<img src="https://github.com/user-attachments/assets/a8c07ef8-8d12-4871-a69a-4b5266edd221" width="400"/>

---

### 👨‍💻 Author
Developed by @aliseyeap.

### 📄 License
This project is developed for academic purposes and is not intended for commercial distribution. Please consult the authors for reuse or enhancement.
