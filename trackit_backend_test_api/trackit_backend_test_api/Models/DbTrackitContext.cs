using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace trackit_backend_test_api.Models;

public partial class DbTrackitContext : DbContext
{
    public DbTrackitContext()
    {
    }

    public DbTrackitContext(DbContextOptions<DbTrackitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentsDetail> CommentsDetails { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Link> Links { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAssigned> ProjectAssigneds { get; set; }

    public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportsDetail> ReportsDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskDetail> TaskDetails { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamAssigned> TeamAssigneds { get; set; }

    public virtual DbSet<TeamsDetail> TeamsDetails { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserPoint> UserPoints { get; set; }

    public virtual DbSet<UserStory> UserStories { get; set; }

    public virtual DbSet<UserStoryDetail> UserStoryDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-44LIK56;Database=DB_TRACKIT;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentsId);

            entity.ToTable("ATTACHMENTS");

            entity.Property(e => e.AttachmentsId).HasColumnName("ATTACHMENTS_ID");
            entity.Property(e => e.AttachmentsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ATTACHMENTS_CREATED_AT");
            entity.Property(e => e.AttachmentsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ATTACHMENTS_EDITED_AT");
            entity.Property(e => e.AttachmentsStatus).HasColumnName("ATTACHMENTS_STATUS");
            entity.Property(e => e.AttachmentsTaskId).HasColumnName("ATTACHMENTS_TASK_ID");

            entity.HasOne(d => d.AttachmentsTask).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.AttachmentsTaskId)
                .HasConstraintName("FK_ATTACHMENTS_TASK_TO_TASK");
        });

        modelBuilder.Entity<Auth>(entity =>
        {
            entity.ToTable("AUTH");

            entity.Property(e => e.AuthId).HasColumnName("AUTH_ID");
            entity.Property(e => e.AuthCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("AUTH_CREATED_AT");
            entity.Property(e => e.AuthCreatedBy).HasColumnName("AUTH_CREATED_BY");
            entity.Property(e => e.AuthEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("AUTH_EDITED_AT");
            entity.Property(e => e.AuthEditedBy).HasColumnName("AUTH_EDITED_BY");
            entity.Property(e => e.AuthStatus).HasColumnName("AUTH_STATUS");
            entity.Property(e => e.AuthType)
                .HasMaxLength(50)
                .HasColumnName("AUTH_TYPE");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Cid);

            entity.ToTable("COMMENTS");

            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.CommentsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COMMENTS_CREATED_AT");
            entity.Property(e => e.CommentsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COMMENTS_EDITED_AT");
            entity.Property(e => e.CommentsId).HasColumnName("COMMENTS_ID");
            entity.Property(e => e.CommentsStatus).HasColumnName("COMMENTS_STATUS");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.Comments).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CommentsId)
                .HasConstraintName("FK_COMMENTS_COMMENTS_DETAILS_TO_COMMENTS_DETAILS");

            entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_COMMENTS_TASK_TO_TASK");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_COMMENTS_USER_TO_USER");
        });

        modelBuilder.Entity<CommentsDetail>(entity =>
        {
            entity.HasKey(e => e.CommentsId);

            entity.ToTable("COMMENTS_DETAILS");

            entity.Property(e => e.CommentsId).HasColumnName("COMMENTS_ID");
            entity.Property(e => e.CommentsDetailsComment)
                .HasMaxLength(500)
                .HasColumnName("COMMENTS_DETAILS_COMMENT");
            entity.Property(e => e.CommentsDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COMMENTS_DETAILS_CREATED_AT");
            entity.Property(e => e.CommentsDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COMMENTS_DETAILS_EDITED_AT");
            entity.Property(e => e.CommentsDetailsStatus).HasColumnName("COMMENTS_DETAILS_STATUS");
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.ToTable("COVER");

            entity.Property(e => e.CoverId).HasColumnName("COVER_ID");
            entity.Property(e => e.CoverCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COVER_CREATED_AT");
            entity.Property(e => e.CoverData).HasColumnName("COVER_DATA");
            entity.Property(e => e.CoverEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("COVER_EDITED_AT");
            entity.Property(e => e.CoverStatus).HasColumnName("COVER_STATUS");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK_IMAGE_ID");

            entity.ToTable("IMAGE");

            entity.Property(e => e.ImageId).HasColumnName("IMAGE_ID");
            entity.Property(e => e.AttachmentsId).HasColumnName("ATTACHMENTS_ID");
            entity.Property(e => e.ImageCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("IMAGE_CREATED_AT");
            entity.Property(e => e.ImageEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("IMAGE_EDITED_AT");
            entity.Property(e => e.ImageLink).HasColumnName("IMAGE_LINK");
            entity.Property(e => e.ImageStatus).HasColumnName("IMAGE_STATUS");

            entity.HasOne(d => d.Attachments).WithMany(p => p.Images)
                .HasForeignKey(d => d.AttachmentsId)
                .HasConstraintName("FK_IMAGE_ATTACHMENTS_TO_ATTACHMENTS");
        });

        modelBuilder.Entity<Link>(entity =>
        {
            entity.HasKey(e => e.LinkId).HasName("PK_LINK_ID");

            entity.ToTable("LINK");

            entity.Property(e => e.LinkId).HasColumnName("LINK_ID");
            entity.Property(e => e.AttachmentsId).HasColumnName("ATTACHMENTS_ID");
            entity.Property(e => e.LinkCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("LINK_CREATED_AT");
            entity.Property(e => e.LinkEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("LINK_EDITED_AT");
            entity.Property(e => e.LinkLink).HasColumnName("LINK_LINK");
            entity.Property(e => e.LinkStatus).HasColumnName("LINK_STATUS");

            entity.HasOne(d => d.Attachments).WithMany(p => p.Links)
                .HasForeignKey(d => d.AttachmentsId)
                .HasConstraintName("FK_LINK_ATTACHMENTS_TO_ATTACHMENTS");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("PROFILE");

            entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");
            entity.Property(e => e.ProfileCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROFILE_CREATED_AT");
            entity.Property(e => e.ProfileData).HasColumnName("PROFILE_DATA");
            entity.Property(e => e.ProfileEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROFILE_EDITED_AT");
            entity.Property(e => e.ProfileStatus).HasColumnName("PROFILE_STATUS");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("PROJECT");

            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.ProjectCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_CREATED_AT");
            entity.Property(e => e.ProjectEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_EDITED_AT");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .HasColumnName("PROJECT_NAME");
            entity.Property(e => e.ProjectStatus).HasColumnName("PROJECT_STATUS");
        });

        modelBuilder.Entity<ProjectAssigned>(entity =>
        {
            entity.ToTable("PROJECT_ASSIGNED");

            entity.Property(e => e.ProjectAssignedId).HasColumnName("PROJECT_ASSIGNED_ID");
            entity.Property(e => e.ProjectAssignedCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_ASSIGNED_CREATED_AT");
            entity.Property(e => e.ProjectAssignedEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_ASSIGNED_EDITED_AT");
            entity.Property(e => e.ProjectAssignedStatus).HasColumnName("PROJECT_ASSIGNED_STATUS");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.TeamId).HasColumnName("TEAM_ID");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectAssigneds)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_PROJECT_ASSIGNED_PROJECT_TO_PROJECT");

            entity.HasOne(d => d.Team).WithMany(p => p.ProjectAssigneds)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_PROJECT_ASSIGNED_TEAM_TO_TEAM");
        });

        modelBuilder.Entity<ProjectDetail>(entity =>
        {
            entity.HasKey(e => e.ProjectDetailsId).HasName("PK_PROJECT_DETAILS_ID");

            entity.ToTable("PROJECT_DETAILS");

            entity.Property(e => e.ProjectDetailsId).HasColumnName("PROJECT_DETAILS_ID");
            entity.Property(e => e.ProjectDetailsCoverId).HasColumnName("PROJECT_DETAILS_COVER_ID");
            entity.Property(e => e.ProjectDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_DETAILS_CREATED_AT");
            entity.Property(e => e.ProjectDetailsDescription)
                .HasMaxLength(500)
                .HasColumnName("PROJECT_DETAILS_DESCRIPTION");
            entity.Property(e => e.ProjectDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PROJECT_DETAILS_EDITED_AT");
            entity.Property(e => e.ProjectDetailsProfileId).HasColumnName("PROJECT_DETAILS_PROFILE_ID");
            entity.Property(e => e.ProjectDetailsRoleId).HasColumnName("PROJECT_DETAILS_ROLE_ID");
            entity.Property(e => e.ProjectDetailsStatus).HasColumnName("PROJECT_DETAILS_STATUS");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");

            entity.HasOne(d => d.ProjectDetailsCover).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.ProjectDetailsCoverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PROJECT_DETAILS_COVER_TO_COVER");

            entity.HasOne(d => d.ProjectDetailsProfile).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.ProjectDetailsProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PROJECT_DETAILS_PROFILE_TO_PROFILE");

            entity.HasOne(d => d.ProjectDetailsRole).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.ProjectDetailsRoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PROJECT_DETAILS_ROLE_TO_ROLE");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectDetails)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_PROJECT_DETAILS_PROJECT_TO_PROJECT");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("REFRESH_TOKEN");

            entity.Property(e => e.RefreshTokenId).HasColumnName("REFRESH_TOKEN_ID");
            entity.Property(e => e.RefreshToken1).HasColumnName("REFRESH_TOKEN");
            entity.Property(e => e.RefreshTokenStatus).HasColumnName("REFRESH_TOKEN_STATUS");
            entity.Property(e => e.RefreshTokenUid).HasColumnName("REFRESH_TOKEN_UID");

            entity.HasOne(d => d.RefreshTokenU).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.RefreshTokenUid)
                .HasConstraintName("FK_REFRESH_TOKEN_USER_TO_USER");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.ToTable("REPORTS");

            entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");
            entity.Property(e => e.ReportCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REPORT_CREATED_AT");
            entity.Property(e => e.ReportDetailsId).HasColumnName("REPORT_DETAILS_ID");
            entity.Property(e => e.ReportEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REPORT_EDITED_AT");
            entity.Property(e => e.ReportProjectId).HasColumnName("REPORT_PROJECT_ID");
            entity.Property(e => e.ReportStatus).HasColumnName("REPORT_STATUS");

            entity.HasOne(d => d.ReportDetails).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ReportDetailsId)
                .HasConstraintName("FK_REPORTS_REPORT_DETAILS_TO_REPORT_DETAILS");

            entity.HasOne(d => d.ReportProject).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ReportProjectId)
                .HasConstraintName("FK_REPORTS_PROJECT_TO_PROJECT");
        });

        modelBuilder.Entity<ReportsDetail>(entity =>
        {
            entity.HasKey(e => e.ReportDetailsId);

            entity.ToTable("REPORTS_DETAILS");

            entity.Property(e => e.ReportDetailsId).HasColumnName("REPORT_DETAILS_ID");
            entity.Property(e => e.ReportData).HasColumnName("REPORT_DATA");
            entity.Property(e => e.ReportDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DETAILS_CREATED_AT");
            entity.Property(e => e.ReportDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("REPORT_DETAILS_EDITED_AT");
            entity.Property(e => e.ReportDetailsStatus).HasColumnName("REPORT_DETAILS_STATUS");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("ROLE");

            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.RoleCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ROLE_CREATED_AT");
            entity.Property(e => e.RoleEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ROLE_EDITED_AT");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("ROLE_NAME");
            entity.Property(e => e.RoleStatus).HasColumnName("ROLE_STATUS");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("TASK", tb => tb.HasTrigger("TR_ATTACHMENT_TABLE_CREATED_AT_TASK_CREATION"));

            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.TaskCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TASK_CREATED_AT");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(500)
                .HasColumnName("TASK_DESCRIPTION");
            entity.Property(e => e.TaskEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TASK_EDITED_AT");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .HasColumnName("TASK_NAME");
            entity.Property(e => e.TaskStatus).HasColumnName("TASK_STATUS");
        });

        modelBuilder.Entity<TaskDetail>(entity =>
        {
            entity.HasKey(e => e.TaskDetailsId).HasName("PK_TASK_DETAILS_ID");

            entity.ToTable("TASK_DETAILS");

            entity.Property(e => e.TaskDetailsId).HasColumnName("TASK_DETAILS_ID");
            entity.Property(e => e.TaskDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TASK_DETAILS_CREATED_AT");
            entity.Property(e => e.TaskDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TASK_DETAILS_EDITED_AT");
            entity.Property(e => e.TaskDetailsEndDate)
                .HasColumnType("datetime")
                .HasColumnName("TASK_DETAILS_END_DATE");
            entity.Property(e => e.TaskDetailsMainTask).HasColumnName("TASK_DETAILS_MAIN_TASK");
            entity.Property(e => e.TaskDetailsPriority)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TASK_DETAILS_PRIORITY");
            entity.Property(e => e.TaskDetailsStartDate)
                .HasColumnType("datetime")
                .HasColumnName("TASK_DETAILS_START_DATE");
            entity.Property(e => e.TaskDetailsStatus).HasColumnName("TASK_DETAILS_STATUS");
            entity.Property(e => e.TaskDetailsSubTask).HasColumnName("TASK_DETAILS_SUB_TASK");
            entity.Property(e => e.TaskDetailsTypeId).HasColumnName("TASK_DETAILS_TYPE_ID");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");

            entity.HasOne(d => d.TaskDetailsType).WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.TaskDetailsTypeId)
                .HasConstraintName("FK_TASK_DETAILS_TYPE_TO_TYPE");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_TASK_DETAILS_TASK_TO_TASK");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("TEAMS");

            entity.Property(e => e.TeamId).HasColumnName("TEAM_ID");
            entity.Property(e => e.TeamCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_CREATED_AT");
            entity.Property(e => e.TeamEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_EDITED_AT");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .HasColumnName("TEAM_NAME");
            entity.Property(e => e.TeamStatus).HasColumnName("TEAM_STATUS");
        });

        modelBuilder.Entity<TeamAssigned>(entity =>
        {
            entity.ToTable("TEAM_ASSIGNED");

            entity.Property(e => e.TeamAssignedId).HasColumnName("TEAM_ASSIGNED_ID");
            entity.Property(e => e.TeamAssignedCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_ASSIGNED_CREATED_AT");
            entity.Property(e => e.TeamAssignedEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_ASSIGNED_EDITED_AT");
            entity.Property(e => e.TeamAssignedStatus).HasColumnName("TEAM_ASSIGNED_STATUS");
            entity.Property(e => e.TeamId).HasColumnName("TEAM_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamAssigneds)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_TEAM_ASSIGNED_TEAM_TO_TEAM");

            entity.HasOne(d => d.User).WithMany(p => p.TeamAssigneds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TEAM_ASSIGNED_USER_TO_USER");
        });

        modelBuilder.Entity<TeamsDetail>(entity =>
        {
            entity.HasKey(e => e.TeamDetailsId);

            entity.ToTable("TEAMS_DETAILS");

            entity.Property(e => e.TeamDetailsId).HasColumnName("TEAM_DETAILS_ID");
            entity.Property(e => e.TeamDetailsCoverId).HasColumnName("TEAM_DETAILS_COVER_ID");
            entity.Property(e => e.TeamDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_DETAILS_CREATED_AT");
            entity.Property(e => e.TeamDetailsDescription)
                .HasMaxLength(500)
                .HasColumnName("TEAM_DETAILS_DESCRIPTION");
            entity.Property(e => e.TeamDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TEAM_DETAILS_EDITED_AT");
            entity.Property(e => e.TeamDetailsProfileId).HasColumnName("TEAM_DETAILS_PROFILE_ID");
            entity.Property(e => e.TeamDetailsRoleId).HasColumnName("TEAM_DETAILS_ROLE_ID");
            entity.Property(e => e.TeamDetailsStatus).HasColumnName("TEAM_DETAILS_STATUS");
            entity.Property(e => e.TeamId).HasColumnName("TEAM_ID");

            entity.HasOne(d => d.TeamDetailsCover).WithMany(p => p.TeamsDetails)
                .HasForeignKey(d => d.TeamDetailsCoverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TEAMS_DETAILS_COVER_TO_COVER");

            entity.HasOne(d => d.TeamDetailsProfile).WithMany(p => p.TeamsDetails)
                .HasForeignKey(d => d.TeamDetailsProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TEAMS_DETAILS_PROFILE_TO_PROFILE");

            entity.HasOne(d => d.TeamDetailsRole).WithMany(p => p.TeamsDetails)
                .HasForeignKey(d => d.TeamDetailsRoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TEAMS_DETAILS_ROLE_TO_ROLE");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamsDetails)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_TEAMS_DETAILS_TEAM_TO_TEAM");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.ToTable("TYPE");

            entity.Property(e => e.TypeId).HasColumnName("TYPE_ID");
            entity.Property(e => e.TypeCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TYPE_CREATED_AT");
            entity.Property(e => e.TypeEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("TYPE_EDITED_AT");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("TYPE_NAME");
            entity.Property(e => e.TypeStatus).HasColumnName("TYPE_STATUS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("USER", tb => tb.HasTrigger("TR_USER_POINTS_TABLE_CREATED_AT_USER_CREATION"));

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UserCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_CREATED_AT");
            entity.Property(e => e.UserEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_EDITED_AT");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .HasColumnName("USER_PASSWORD");
            entity.Property(e => e.UserStatus).HasColumnName("USER_STATUS");
            entity.Property(e => e.UserUuid)
                .HasMaxLength(500)
                .HasColumnName("USER_UUID");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserDetailsId).HasName("PK_USER_DETAILS_ID");

            entity.ToTable("USER_DETAILS");

            entity.Property(e => e.UserDetailsId).HasColumnName("USER_DETAILS_ID");
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UserDetailsAuthId).HasColumnName("USER_DETAILS_AUTH_ID");
            entity.Property(e => e.UserDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_DETAILS_CREATED_AT");
            entity.Property(e => e.UserDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_DETAILS_EDITED_AT");
            entity.Property(e => e.UserDetailsFirstname)
                .HasMaxLength(50)
                .HasColumnName("USER_DETAILS_FIRSTNAME");
            entity.Property(e => e.UserDetailsLastname)
                .HasMaxLength(50)
                .HasColumnName("USER_DETAILS_LASTNAME");
            entity.Property(e => e.UserDetailsRoleId).HasColumnName("USER_DETAILS_ROLE_ID");
            entity.Property(e => e.UserDetailsStatus).HasColumnName("USER_DETAILS_STATUS");
            entity.Property(e => e.UserDetailsUsername)
                .HasMaxLength(50)
                .HasColumnName("USER_DETAILS_USERNAME");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_USER_DETAILS_USER_TO_USER");

            entity.HasOne(d => d.UserDetailsAuth).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserDetailsAuthId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_DETAILS_AUTH_TO_AUTH");

            entity.HasOne(d => d.UserDetailsRole).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserDetailsRoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_DETAILS_ROLE_TO_ROLE");
        });

        modelBuilder.Entity<UserPoint>(entity =>
        {
            entity.HasKey(e => e.UserPointsId).HasName("PK_USER_POINTS_ID");

            entity.ToTable("USER_POINTS");

            entity.Property(e => e.UserPointsId).HasColumnName("USER_POINTS_ID");
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UserIsAvaible).HasColumnName("USER_IS_AVAIBLE");
            entity.Property(e => e.UserPointsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_POINTS_CREATED_AT");
            entity.Property(e => e.UserPointsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_POINTS_EDITED_AT");
            entity.Property(e => e.UserPointsStatus).HasColumnName("USER_POINTS_STATUS");
            entity.Property(e => e.UserPointsTotal).HasColumnName("USER_POINTS_TOTAL");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.UserPoints)
                .HasForeignKey(d => d.Uid)
                .HasConstraintName("FK_USER_POINTS_USER_TO_USER");
        });

        modelBuilder.Entity<UserStory>(entity =>
        {
            entity.ToTable("USER_STORY");

            entity.Property(e => e.UserStoryId).HasColumnName("USER_STORY_ID");
            entity.Property(e => e.UserStoryCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_CREATED_AT");
            entity.Property(e => e.UserStoryDescription)
                .HasMaxLength(500)
                .HasColumnName("USER_STORY_DESCRIPTION");
            entity.Property(e => e.UserStoryEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_EDITED_AT");
            entity.Property(e => e.UserStoryName)
                .HasMaxLength(50)
                .HasColumnName("USER_STORY_NAME");
            entity.Property(e => e.UserStoryStatus).HasColumnName("USER_STORY_STATUS");
        });

        modelBuilder.Entity<UserStoryDetail>(entity =>
        {
            entity.HasKey(e => e.UserStoryDetailsId).HasName("PK_USER_STORY_DETAILS_ID");

            entity.ToTable("USER_STORY_DETAILS");

            entity.Property(e => e.UserStoryDetailsId).HasColumnName("USER_STORY_DETAILS_ID");
            entity.Property(e => e.UserStoryDetailsCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_DETAILS_CREATED_AT");
            entity.Property(e => e.UserStoryDetailsEditedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_DETAILS_EDITED_AT");
            entity.Property(e => e.UserStoryDetailsEndDate)
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_DETAILS_END_DATE");
            entity.Property(e => e.UserStoryDetailsMainTask).HasColumnName("USER_STORY_DETAILS_MAIN_TASK");
            entity.Property(e => e.UserStoryDetailsPriority)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("USER_STORY_DETAILS_PRIORITY");
            entity.Property(e => e.UserStoryDetailsStartDate)
                .HasColumnType("datetime")
                .HasColumnName("USER_STORY_DETAILS_START_DATE");
            entity.Property(e => e.UserStoryDetailsStatus).HasColumnName("USER_STORY_DETAILS_STATUS");
            entity.Property(e => e.UserStoryDetailsSubTask).HasColumnName("USER_STORY_DETAILS_SUB_TASK");
            entity.Property(e => e.UserStoryDetailsTypeId).HasColumnName("USER_STORY_DETAILS_TYPE_ID");
            entity.Property(e => e.UserStoryId).HasColumnName("USER_STORY_ID");

            entity.HasOne(d => d.UserStoryDetailsType).WithMany(p => p.UserStoryDetails)
                .HasForeignKey(d => d.UserStoryDetailsTypeId)
                .HasConstraintName("FK_USER_STORY_DETAILS_TYPE_TO_TYPE");

            entity.HasOne(d => d.UserStory).WithMany(p => p.UserStoryDetails)
                .HasForeignKey(d => d.UserStoryId)
                .HasConstraintName("FK_USER_STORY_DETAILS_TASK_TO_TASK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
