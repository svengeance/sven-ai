<template>
  <v-container class="pb-6 px-xl-16 px-0">
    <p class="text-md-h6 text-subtitle-2 text-center px-4">
      The following charts represent a broad self-assessment of familiarity and recency-of-use of typical development facets, lighter colors indicating higher competency
    </p>
    <v-divider />
    <v-row align-content="center" class="mx-0">
      <v-col v-for="chart in charts" :key="chart.title" offset-lg="1" lg="10" cols="12" class="my-lg-8 my-sm-4 px-0 px-xl-16">
        <BarChart :values="chart.values" :labels="chart.labels" :title="chart.title" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    charts:
    [
      {
        title: 'Languages',
        labels: ['C#', 'Typescript', 'T-SQL', 'Python', 'Pascal'],
        values: [10, 7, 6, 4, 3]
      },
      {
        title: 'Frameworks & Libraries',
        labels: ['ASP.NET Core', 'EF Core', 'Vue JS', 'Angular (v4+)', 'Redux'],
        values: [10, 10, 7, 6, 5]
      },
      {
        title: 'Tools/IDEs',
        labels: ['Visual Studio', 'VS Code', 'Git', 'Docker', 'MS-SQL'],
        values: [10, 8, 8, 6, 6]
      },
      {
        title: 'Development Stack',
        labels: ['Web', 'Desktop', 'API', 'Database', 'DevOps'],
        values: [8, 6, 10, 7, 8]
      }
    ]
  }),
  head() {
    return {
      title: 'Skillset'
    }
  }
}
</script>
