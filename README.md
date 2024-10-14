# Job Board Application (Backend in C# with ASP.NET Core)

## Introduction
Ce projet de Job Board (site d'offres d'emploi) est conçu avec **C#** et **ASP.NET Core**. Il comprend diverses fonctionnalités côté back-end pour gérer les utilisateurs, les offres d'emploi, les candidatures, et bien plus encore. Le back-end est responsable de la gestion des données, de la sécurité, et des requêtes envoyées par le front-end.

## 1. Structure des données

La base de données du Job Board contient plusieurs entités essentielles, modélisées avec **Entity Framework Core**. Voici les principales entités à définir :

### 1.1 Modèles de base de données

1. **Utilisateur (`User`)** :
    - Propriétés : `Id`, `Username`, `Email`, `PasswordHash`, `Role` (Candidat ou Employeur)
    - Rôles : Un utilisateur peut être un **Candidat** ou un **Employeur**.
    - Le mot de passe est stocké sous forme de hachage pour des raisons de sécurité.

2. **Offre d'emploi (`Job`)** :
    - Propriétés : `Id`, `Title`, `Description`, `PostId`, `CompanyName`, `Location`, `Salary`, `PostedDate`, `EmployerId`, `Status` (actif, expiré)
    - Relation : Chaque offre d'emploi est liée à un **employeur** via `EmployerId`.

3. **Candidature (`Application`)** :
    - Propriétés : `Id`, `JobId`, `CandidateId`, `CoverLetter`, `Resume`, `ApplicationDate`, `Status` (acceptée, en attente, refusée)
    - Relation : Chaque candidature est liée à un **candidat** et une **offre d'emploi**.

4. **Profil candidat (`CandidateProfile`)** :
    - Propriétés : `Id`, `UserId`, `FullName`, `Experience`, `Education`, `Skills`, `ResumeUrl`
    - Relation : Chaque candidat peut avoir un profil avec ses informations personnelles et qualifications.


### Fonctionnalités à développer

### 1. Inscription et gestion des utilisateurs
- **Inscription et connexion** : Permettre aux utilisateurs de s'inscrire et de se connecter en tant qu'employeur ou candidat.
- **Hachage sécurisé des mots de passe** : Utilisation d'ASP.NET Identity pour hacher les mots de passe avant de les stocker.
- **Gestion des rôles** : Définir les rôles "Candidat" et "Employeur" afin de contrôler les permissions et actions autorisées pour chaque type d'utilisateur.

### 2. Création et gestion des offres d’emploi (Employeurs)
- **Créer une offre d'emploi** : Les employeurs peuvent créer une nouvelle offre d'emploi en ajoutant des détails tels que le titre, la description, la localisation, le salaire, etc.
- **Modifier une offre d'emploi** : Les employeurs peuvent modifier leurs offres d'emploi si elles sont encore actives.
- **Supprimer ou archiver une offre d'emploi** : Les employeurs peuvent désactiver ou archiver les offres d'emploi une fois que le poste est pourvu.
- **Afficher la liste des offres d'emploi** : Affichage des offres d'emploi actives sur le site, visibles pour les candidats.

### 3. Recherche et affichage des offres d’emploi (Candidats)
- **Recherche d'offres d'emploi** : Permettre aux candidats de rechercher des offres d'emploi par titre, localisation, salaire, ou autres critères.
- **Voir les détails d'une offre d'emploi** : Les candidats peuvent afficher les détails complets d'une offre d'emploi (description, entreprise, localisation, etc.).

### 4. Candidature à une offre d’emploi (Candidats)
- **Soumettre une candidature** : Les candidats peuvent postuler à une offre d'emploi en joignant leur CV et une lettre de motivation.
- **Gestion des candidatures** : Les employeurs peuvent consulter, accepter ou rejeter les candidatures soumises pour leurs offres d'emploi.

### 5. Gestion du profil candidat
- **Créer et modifier un profil** : Les candidats peuvent créer et mettre à jour leur profil avec des informations sur leur expérience professionnelle, leurs compétences, et leur CV.
- **Téléchargement de CV** : Permettre aux candidats d’ajouter ou de remplacer leur CV sur leur profil.

### 6. Notifications (Facultatif)
- **Notifications d'expiration des offres** : Les employeurs reçoivent des notifications lorsque leurs offres d'emploi expirent ou doivent être renouvelées.
- **Suivi des candidatures** : Les candidats reçoivent des notifications lorsque leur candidature est acceptée, rejetée ou en attente.

### 7. Authentification et gestion des rôles
- **Authentification sécurisée** : Utiliser ASP.NET Identity pour gérer l'inscription, la connexion, et l'authentification des utilisateurs.
- **Rôles utilisateur** : Gérer les rôles pour limiter les actions possibles aux utilisateurs en fonction de leur type (employeur ou candidat).



### Exemple de modèle de base de données :

```csharp
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // "Candidate" or "Employer"
}

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }
    public DateTime PostedDate { get; set; }
    public int EmployerId { get; set; }
    public string Status { get; set; } // "Active", "Expired"
}

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int CandidateId { get; set; }
    public string CoverLetter { get; set; }
    public string Resume { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Status { get; set; } // "Pending", "Accepted", "Rejected"
}

