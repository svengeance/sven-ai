<template>
  <v-sheet elevation="6" class="root" height="100vh">
    <v-container class="pa-0">
      <v-row class="pb-4 px-4 py-0 site-header-component feed-header">
        <span class="text-caption feed-header-label grey--text text--darken-1 text-center font-weight-bold">Github Activity Feed</span>
        <v-col cols="2" class="d-flex align-center justify-center">
          <a :href="gitProfile.htmlUrl" target="_blank">
            <v-avatar size="64px">
              <v-img :src="gitProfile.avatarUrl" />
            </v-avatar>
          </a>
        </v-col>
        <v-col cols="10" class="px-0 d-flex flex-column justify-center profile-info">
          <span>
            <a :href="gitProfile.htmlUrl" target="_blank" class="text-h5 grey--text text--lighten-1">
              Svengeance
            </a>
          </span>
          <span class="text-subtitle-2 grey--text text--lighten-2">{{ gitProfile.bio }}</span>
        </v-col>
        <div class="px-2 text-caption feed-footer-label grey--text">
          <span class="float-left">Repositories: {{ gitProfile.numPublicRepos }} public, {{ gitProfile.numPrivateRepos }} private</span>
          <span class="float-right">Gists: {{ gitProfile.numPublicGists }} public, {{ gitProfile.numPrivateGists }} private</span>
        </div>
      </v-row>
      <v-divider />
      <v-row>
        <perfect-scrollbar>
          <v-col v-for="feedItem of gitFeed" :key="feedItem.id" class="pb-0 pt-2" cols="12">
            <div class="activity-item-container px-4 d-flex flex-column grey--text text--lighten-2">
              <span class="activity-item-header text-caption grey--text">
                <span class="float-left">{{ feedItem.date }} </span>
                <span class="float-right"><a :href="feedItem.repo.url" target="_blank">{{ feedItem.repo.name }}</a></span>
              </span>
              <span class="text-body-1">
                <v-icon class="blue--text text--darken-2">mdi-{{ feedItem.icon }}</v-icon>
                {{ feedItem.action.verbSentence }}
              </span>
              <span v-if="feedItem.action.title" class="text-body-1">{{ feedItem.action.title }}</span>
              <span v-if="feedItem.action.subtitle" class="text-dense text-subtitle-2">{{ feedItem.action.subtitle }}</span>
              <span v-if="feedItem.action.caption" class="text-caption">{{ feedItem.action.caption }}</span>
              <a :href="feedItem.action.link" class="text-caption mt-2" target="_blank">{{ feedItem.action.linkText }} </a>
            </div>
            <v-divider class="mt-2" />
          </v-col>
        </perfect-scrollbar>
      </v-row>
    </v-container>
  </v-sheet>
</template>

<style lang="scss">
  .ps__rail-y {
    margin-right: 12px !important;
  }
  .ps {
    height: calc(100vh - 1px - #{$header-height})
  }
</style>

<style lang="scss" scoped>
  .text-dense {
    line-height: 16px;
  }
  .feed-header {
    position: relative;
  }
  .feed-header-label {
    position: absolute;
    width: 100%;
  }
  .feed-footer-label {
    bottom: 0;
    position: relative;
    width: 100%;
  }
  .root {
    position: relative;
    a {
       text-decoration: none;
    }
   }
</style>

<script>
const iconMap = {
  CommitCommentEvent: 'comment-text',
  CreateEvent: 'source-branch-plus',
  DeleteEvent: 'source-branch-remove',
  ForkEvent: 'source-fork',
  GollumEvent: 'file-document-multiple',
  IssueCommentEvent: 'comment-alert',
  IssuesEvent: 'bug',
  MemberEvent: 'account-group',
  PublicEvent: 'party-popper',
  PullRequestEvent: 'source-pull',
  PullRequestReviewCommentEvent: 'comment-eye',
  PushEvent: 'playlist-plus',
  ReleaseEvent: 'bullhorn',
  SponsorshipEvent: 'charity',
  WatchEvent: 'star-circle'
}

export default {
  data() {
    return {
      gitProfile: {
        avatarUrl: '',
        blog: '',
        bio: '',
        hireable: false,
        htmlUrl: '',
        numPrivateGists: 0,
        numPrivateRepos: 0,
        numPublicRepos: 0,
        numPublicGists: 0
      },
      gitFeed: [
        {
          id: '',
          date: '',
          isPublic: false,
          activityType: '',
          actor: {
            displayName: 'svengeance',
            avatarUrl: ''
          },
          repo: {
            name: '',
            url: ''
          },
          action: {
            verbSentence: '',
            title: '',
            subtitle: '',
            caption: '',
            link: '',
            linkText: ''
          }
        }
      ]
    }
  },
  async fetch() {
    this.gitProfile = await this.$http.$get('api/Git/Users/Me')
    this.gitFeed = (await this.$http.$get('api/Git/Users/Me/Activity')).map(m => ({ ...m, icon: iconMap[m.activityType] }))
  }
}
</script>
