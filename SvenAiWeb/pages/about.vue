<template>
  <v-layout class="content pt-2 pb-8">
    <v-row class="mx-0 mr-n2">
      <v-col offset="1" cols="10">
        <v-img class="about-image float-left mr-4 mb-1" width="100%" max-width="600px"
               src="/images/cat/cat_w1000.jpg"
               sizes="(max-width: 2000px) 50vw, 600px"
               srcset="/images/cat/cat_w384.jpg 384w,
                      /images/cat/cat_w504.jpg 504w,
                      /images/cat/cat_w606.jpg 606w,
                      /images/cat/cat_w699.jpg 699w,
                      /images/cat/cat_w790.jpg 790w,
                      /images/cat/cat_w886.jpg 886w,
                      /images/cat/cat_w975.jpg 975w,
                      /images/cat/cat_w1000.jpg 1000w"
        >
          <span>Please enjoy this picture of my cats while I struggle to obtain my own</span>
        </v-img>
        <p class="text-h2 grey--text text--lighten-2">
          Hello, world!
        </p>
        <v-divider />
        <p class="text-h5 grey--text text--lighten-1 pt-6">
          I'm Stephen Vernyi, aka Sven, developing software primarily in C#/.NET using a wide array of Microsoft/Azure products and SDKs.
          I am currently based in Columbus Ohio, working at Select Sires Inc as a senior software developer.
          My day-to-day has me working with various teams across different technology stacks in order to produce the best applications our industry has ever known.
        </p>
        <div class="text-body-1 grey--text text--lighten-1">
          <p class="text-h6 text--lighten-3 text-decoration-underline">
            University
          </p>
          <p>
            I graduated from <i>The</i> Ohio State University in 2017, taking a rather niche degree in GIS (Geographic Information Systems), a data-heavy field that utilizes software to analyze geographical information.
            While this coursework gave me valuable insights into a unique field, I spent the majority of my time maximizing my interactions with the software development
            portion of this degree. I'd already known going into University that I loved writing software and developing applications, and nothing about that had changed.
          </p>
          <p class="text-h6 text--lighten-3 text-decoration-underline">
            Internships
          </p>
          <p>
            During the final two years of my university work I held an internship at ACUHO-I, an association dedicated to assisting univeristy housing &amp; dormitory programs internationally.
            Ultimately the experience and mentorship I had here kicked off my interest, and career, in C# and .NET technologies at large. It was also here that I developed some small skills
            working on web interfaces and client applications through some now-dated web stacks such as JQuery, Bootstrap (2), KnockoutJS, etc. This combination gave me the breadth of
            knowledge I needed to put forward my own personal projects, and through this experience I landed my first job at Select Sires.
          </p>
          <p class="text-h6 text--lighten-3 text-decoration-underline">
            Current Work
          </p>
          <p>
            Working at Select Sires thus far has truly been a pleasure. The industry is very unique, and surprisingly challenging.
            The breadth and depth of the data we serve demands heavy attention to detail, as each marketable product we publicize has some few hundred datapoints associated, each of which must
            adhere to the standards of the organization that published them.
            <br>
            Perhaps the most educating experience from my time so far at Select Sires can be found in the auspicious time at which I was hired.
            I joined a team comprised of talented individuals wearing many hats and bearing a mulitude of responsibilities to grow the company's technological front, and
            within a year of having joined the company, I watched our team grow into a full organization, more than tripling in size. We rapidly progressed on various fronts, transitioning from
            Trello to Azure, from copy-and-paste deployments on local servers to CI/CD pipelines in Azure, and from monolithic webservers to fast, easily-deployable microservices.
            Being able to be a part of this and have a hand in assisting on all fronts was an experience that I feel fortunate to have acquired, as I was able to take on responsibilities
            not lightly given to newer graduates.
            <br>
            It was during this time that I was able to take the lead on some larger architectural decisions - upgrading to .NET Core for our primary API, refactoring older code that needed some love,
            and ultimately breaking down our monolithic codebases into more manageable sections.
          </p>
          <p class="text-h6 text--lighten-3 text-decoration-underline">
            Hobbies
          </p>
          <p>
            I spend most of my freetime with my significant other, at the gym, gaming, or hanging out with likeminded individuals in programming servers as we talk about current
            and upcoming technologies. I'm fortunate to be a part of some communities which fosters mutual learning among all members, sometimes from leaders in their respective fields,
            which gives me insights and perspectives I otherwise would never come across.
            <br>
            I play mostly competitive multiplayer games that I can enjoy with friends, such as Overwatch, Smite, Starcraft 2, and League of Legends.
            The layout for this website is actually heavily inspired by the League client.
          </p>
        </div>
      </v-col>
    </v-row>
  </v-layout>
</template>

<style lang="scss" scoped>
  .about-image span {
    bottom: 0;
    position: absolute;
    text-align: center;
    width: 100%;
  }
  .content {
    > div {
      width: 100%; // Fixes the bounding box of the div below "layout.content>div" from overflowing
    } // when going from larger to smaller layouts
    p {
      font-size: 1.25rem;
      line-height: 1.75rem;
      margin-bottom: 24px;

      &.text-h2 {
        line-height: 1;
        margin-bottom: 0px;
      }
    }
    .text-h6 {
      margin-bottom: 0;
    }
  }
</style>

<script>
export default {
  head() {
    return {
      title: 'About'
    }
  }
}
</script>
