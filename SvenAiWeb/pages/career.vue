<template>
  <v-timeline :dense="$vuetify.breakpoint.smAndDown" class="px-md-16">
    <v-timeline-item v-for="item in timelineItems" :key="item.title" class="my-16" color="transparent">
      <template v-slot:opposite>
        <v-img :src="item.logo" height="300" contain />
      </template>
      <template v-slot:icon>
        <v-avatar tile color="transparent">
          <img :src="item.icon">
        </v-avatar>
      </template>
      <v-card class="mx-4 card">
        <v-list-item three-line>
          <v-list-item-content>
            <v-list-item-title class="headline">
              {{ item.title }}
            </v-list-item-title>
            <v-list-item-subtitle>
              <p class="my-2">
                {{ item.subtitle }}
              </p>
              <p class="my-0">
                {{ item.startDate }} - {{ item.endDate }}
              </p>
            </v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
        <v-card-text>
          <span v-html="item.description" />
        </v-card-text>
      </v-card>
    </v-timeline-item>
  </v-timeline>
</template>

<script>
export default {
  data() {
    return {
      timelineItems: [
        {
          title: 'Select Sires',
          subtitle: 'Senior Software Developer - Contractor',
          icon: '/images/career/ssi-icon.png',
          logo: '/images/career/ssi-logo.png',
          description: `
            <p>
              Select Sires was my first job in my professional career coming out of University. I started off working as mid-level developer working on the C# APIs in the company.
              The first project I worked on is actually the company's flagship product: SMS. Lovingly dubbed 'Tinder for Bulls', SMS is a program that seeks to provide the best
              in intelligent mating choices between cows and sires. A megalith chromium desktop application, it has extremely complex features such as online-offline database synchronization,
              complex mating algorithms via linear programming, and a plethora of data importing and massaging.
            </p>
            <p>
              Something unique about this job from the time of my joining is that the company grew immensely, offering all sorts of opportunity for people to grow themselves alongside it.
              From the time I was hired to the present, we've more than tripled our tech department, and I've been able to don a variety of hats as I've helped projects along, from 
              architect, to managing products, and frontend to database development. My resolve to push the envelope and produce quality applications has put me in a position where 
              I have been able to introduce .NET Core to the company back in 2018, and lead development on the newer, modular .NET Core APIs that broke down our monolithic architecture.
            </p>
          `,
          startDate: 'July 2017',
          endDate: 'N/A'
        },
        {
          title: 'OSU Graduation',
          subtitle: 'BA - Geographic Information Science',
          icon: '/images/career/osu-icon.png',
          logo: '/images/career/osu-logo.png',
          description: `
            <p>
              Time at <b>The</b> Ohio State University was some of the best in my life. The various people I'd met, events I'd attended, and classes I was able to take all helped me figure out who I was
              and what I wanted out of life. I had a lot of initial struggles with advanced topics that I didn't understand immediately, which helped me learn <i>how</i> to learn and study, and rapidly
              put to use newly acquired information.
            </p>
            <p>
              Two of my favorite series of classes was the German series, and the Computer Systems/hardware series. The latter went over the physical layout of processors, how assembly is read and loaded
              into registers, what CPU flags are -- all of the gory details of low level computer systems. The latter is a foreign language that I have a high affinity for, which I personally find beautiful.
              My German minor also gave me my nickname for life - Sven. Dafür (und natürlich andere Begründung) liebe ich die Sprache.
            </p>
          `,
          startDate: 'August 2013',
          endDate: 'April 2017'
        },
        {
          title: 'ACUHO-I',
          subtitle: 'Assistant Software Developer - Intern',
          icon: '/images/career/acuhoi-icon.png',
          logo: '/images/career/acuhoi-logo.png',
          description: `
            <p>
              My second internship, ACUHO-I, was my kick-starter into C# and Web Development. Prior, I had only had experience with the likes of Java, C++, and Python, and none of them really <i>clicked</i> for me the way C# does.
            </p>
            <p>
              Early on in this internship I was mostly concerned with minor bug fixes on the company website, which utilized DotNetNuke extensively as a CMS. Membersuite, our backing association data provider, was used to query
              for our various members, events, and roles. We worked to integrate with Noda, another company, in order to provide a seamless experience for users for interfacing with either company.
            </p>
            <p>
              My biggest contribution as an intern was the development of a SPA whose primary purpose was to run as a self check-in kiosk for our largest event. The webapp would be deployed internally and accessible
              by these 'kiosks' by running chrome in kiosk-mode, and would scan in a QR code from a user's badge that identifies them, marking them in our CRM as having checked into the event.
              This contribution removed a huge, manual check-in process and streamlined event attendance for all, and was a success for its first production usage.
            </p>
          `,
          startDate: 'August 2015',
          endDate: 'May 2017'
        },
        {
          title: 'Vogelsang USA',
          subtitle: 'Assistant UI Developer - Intern',
          icon: '/images/career/vogelsang-icon.png',
          logo: '/images/career/vogelsang-logo.png',
          description: `
            <p>
              My first ever experience with professional development was at Vogelsang USA. Headquartered in Germany, the company has subsidiaries all over the world, including one not too far
              from my hometown, in Ravenna, OH.
            </p>
            <p>
              The company itself specializes in manufacturing pumps, cutters, grinders, and other large mechanical machinery. My role in the company was to assist in producing UIs that facilitated 
              access into the database for reports generation and product management. These processes existed beforehand, but not as elegantly.
            </p>
          `,
          startDate: 'January 2014',
          endDate: 'May 2014'
        }
      ]
    }
  },
  head() {
    return {
      title: 'Career'
    }
  }
}
</script>
