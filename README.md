# TalentTrigger

A job monitoring platform that automatically scrapes company career pages and sends email alerts when matching jobs are found.

## 🚀 Features

- **User Authentication**: Magic-link authentication via Supabase
- **Job Watches**: Create custom job search criteria (company, role, experience level)
- **Automated Scraping**: Periodic scraping of company career pages every 15 minutes
- **Smart Matching**: AI-powered job matching against user criteria
- **Email Alerts**: Instant email notifications when matching jobs are found
- **Background Processing**: Robust background job system using Hangfire

## 🏗️ Architecture

- **Backend**: ASP.NET Core 8 Web API (C#)
- **Database**: PostgreSQL (Supabase)
- **Background Jobs**: Hangfire with PostgreSQL storage
- **Authentication**: Supabase Auth with magic links
- **Frontend**: React with Next.js 15 (coming soon)

## 📁 Project Structure

```
TalentTrigger/
├── TalentTrigger.Backend/          # ASP.NET Core Web API
│   ├── Controllers/                # API Controllers
│   ├── Services/                   # Business Logic Services
│   ├── Models/                     # Entity Models
│   ├── Data/                       # Database Context
│   ├── BackgroundJobs/             # Background Job Definitions
│   └── Infrastructure/             # External Service Integrations
└── README.md
```

## 🛠️ Tech Stack

### Backend
- **.NET 8**: Latest .NET framework
- **ASP.NET Core**: Web API framework
- **Entity Framework Core**: ORM for database operations
- **Hangfire**: Background job processing
- **PostgreSQL**: Primary database (via Supabase)
- **Redis**: Caching and session storage
- **Swagger/OpenAPI**: API documentation

### Database Models
- **Watch**: User job search criteria
- **Job**: Scraped job listings
- **SentNotification**: Email notification tracking

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- PostgreSQL database (Supabase recommended)
- Redis (optional, for caching)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/TalentTrigger.git
   cd TalentTrigger
   ```

2. **Configure the backend**
   ```bash
   cd TalentTrigger.Backend
   ```

3. **Update connection strings**
   Edit `appsettings.json` with your database credentials:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "your-postgresql-connection-string"
     },
     "Hangfire": {
       "ConnectionString": "your-postgresql-connection-string"
     }
   }
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Start the application**
   ```bash
   dotnet run
   ```

6. **Access the API**
   - API: http://localhost:5001
   - Swagger UI: http://localhost:5001/swagger
   - Health Check: http://localhost:5001/api/test

## 📋 API Endpoints

### Health Check
- `GET /api/test` - Application health check

### Job Management
- `GET /api/jobs/status` - Background service status
- `POST /api/jobs/trigger-scraping` - Manually trigger job scraping

### Watches (Coming Soon)
- `GET /api/watches` - Get user's job watches
- `POST /api/watches` - Create new job watch
- `PUT /api/watches/{id}` - Update job watch
- `DELETE /api/watches/{id}` - Delete job watch

## 🔧 Configuration

### Environment Variables
- `ConnectionStrings__DefaultConnection`: PostgreSQL connection string
- `ConnectionStrings__Hangfire`: Hangfire PostgreSQL connection string
- `Redis__ConnectionString`: Redis connection string (optional)

### Background Jobs
- **Job Scraping**: Runs every 15 minutes
- **Email Notifications**: Sent within 15 minutes of job discovery
- **Database Cleanup**: Periodic cleanup of old data

## 🧪 Testing

### Manual Testing
1. Start the application: `dotnet run`
2. Visit http://localhost:5001/swagger
3. Test the `/api/test` endpoint
4. Check background service logs

### Automated Testing (Coming Soon)
- Unit tests for services
- Integration tests for API endpoints
- End-to-end tests for job scraping

## 📝 Development

### Adding New Features
1. Create feature branch: `git checkout -b feature/new-feature`
2. Implement changes
3. Add tests
4. Update documentation
5. Create pull request

### Code Style
- Follow C# coding conventions
- Use meaningful variable and method names
- Add XML documentation for public APIs
- Keep methods small and focused

## 🚀 Deployment

### Local Development
```bash
dotnet run --environment Development
```

### Production
```bash
dotnet publish -c Release
dotnet run --environment Production
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

- Create an issue for bugs or feature requests
- Check the [Wiki](https://github.com/yourusername/TalentTrigger/wiki) for documentation
- Join our [Discord](https://discord.gg/talenttrigger) for community support

## 🔮 Roadmap

- [ ] React frontend with Next.js 15
- [ ] Advanced job matching algorithms
- [ ] Email template customization
- [ ] Mobile app (React Native)
- [ ] Analytics dashboard
- [ ] Multi-language support
- [ ] API rate limiting
- [ ] Webhook integrations

---

**Built with ❤️ for job seekers everywhere** 