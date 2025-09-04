# Themis - Software Development Kit (SDK)

The PUBLIC SDK repository - critical component of the PaaS layer (formerly SDK).

## File Structure

```
Themis/                  # PUBLIC SDK repo; critical component of the PaaS layer (formerly SDK)
├── contracts/
│   ├── DTOs/
│   │   ├── ContactDto.cs        # Contact data transfer object
│   │   ├── CompanyDto.cs        # Company data transfer object
│   │   └── EngagementDto.cs     # Engagement data transfer object
│   └── Interfaces/
│       ├── ICRMAdapter.cs       # CRM system integration interface
│       ├── IEngagementAdapter.cs # Engagement service interface
│       └── IWorkflowAdapter.cs  # Workflow orchestration interface
├── adapters/
│   ├── BaseCRMAdapter.cs        # Abstract base class for CRM integrations
│   └── MockAdapter.cs           # Testing and development adapter
├── ui-kit/
│   ├── components/              # Reusable UI components
│   │   ├── Button.tsx
│   │   ├── Form.tsx
│   │   └── Table.tsx
│   └── hooks/                   # Custom React hooks
│       └── useApi.ts            # API integration hook
├── utilities/
│   ├── DateHelpers.cs           # Date utility functions
│   └── ValidationHelpers.cs    # Validation utility functions
├── package.json                 # npm package configuration
└── tsconfig.json               # TypeScript configuration
```

## Overview

Themis provides the software development kit (SDK) for the Pyrick platform, enabling third-party developers to build integrations and custom applications. Named after the goddess of divine law and order, as the SDK defines the API rules and contracts.

## Key Components

### Data Transfer Objects (DTOs)
- **ContactDto.cs** - Standardized contact information structure
- **CompanyDto.cs** - Company/organization data structure  
- **EngagementDto.cs** - Business engagement data structure

### Service Interfaces
- **ICRMAdapter.cs** - Interface for CRM system integrations
- **IEngagementAdapter.cs** - Interface for engagement management
- **IWorkflowAdapter.cs** - Interface for workflow orchestration

### UI Components
- Reusable React components built with TypeScript
- Custom hooks for API integration
- Tailwind CSS styling

### Utilities
- Date manipulation and formatting helpers
- Validation functions for data integrity

## Installation

```bash
npm install @pyrick/themis-sdk
```

## Usage

### TypeScript/JavaScript
```typescript
import { EngagementDto, ICRMAdapter } from '@pyrick/themis-sdk';

const engagement: EngagementDto = {
  id: 'uuid-here',
  title: 'New Business Opportunity',
  // ... other properties
};
```

### C# (.NET)
```csharp
using Pyrick.Themis.Contracts;

var engagement = new EngagementDto
{
  Id = Guid.NewGuid(),
  Title = "New Business Opportunity",
  // ... other properties
};
```

## Development

### Building the SDK
```bash
npm run build
```

### Running Tests
```bash
npm run test
```

### Publishing
```bash
npm publish
```

## Contributing

1. Follow existing code patterns and conventions
2. Add comprehensive tests for new features
3. Update documentation for any API changes
4. Ensure backward compatibility where possible
5. Version changes according to semantic versioning