import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import Restaurant from '../views/Restaurant.vue'
import AboutUs from '../views/AboutUs.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
      }
    },
    {
      path: "/about",
      name: "aboutUs",
      component: AboutUs,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/restaurant/:restaurantId",
      name: "restaurant",
      component: Restaurant,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: () => import('../views/Dashboard.vue'),
    },
    {
      path: '/newParty',
      name: 'newParty',
      component: () => import('../views/NewPartyForm.vue'),
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/party/details/:partyId',
      name: 'party',
      component: () => import('../views/Party.vue'),
      meta: {
        requiresAuth:false
      }
    },
    {
      path: '/tinder/:partyId',
      name: 'tinderMain',
      component: () => import('../views/TinderMain.vue'),
      meta: {
        requiresAuth: false
      }
    },
    {  //TODO: Add these routes back in when they are ready
      path: '/tinder/:partyId/restaurant/:restaurantId',
      name: 'tinderRestaurant',
      component: () => import('../views/TinderRestaurant.vue'),
      meta: {
        requiresAuth: false
      }
    },
    // {
    //   path: '/tinder/:id/standings',
    //   name: 'restaurant',
    //   component: () => import('../views/Restaurant.vue'),
    //   meta: {
    //     requiresAuth: false
    //   }
    // },

    

  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
