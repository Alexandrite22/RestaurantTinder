import axios from 'axios';

export default {

  // create a new api call to retrieve restaurants using the following api endpoint and bearer token
  //Api endpoint: https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=
  //Bearer token: "lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx";
    async getRestaurants(location) {
        try {
            const config = {
                headers: { Authorization: `Bearer ${}` }
            };
                        
            Axios.post( 
              'http://localhost:8000/api/v1/get_token_payloads',
              config
            ).then(console.log).catch(console.log);
            const response = await axios.get(
                `https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=${location}`,
                {
                    headers: {
                        Authorization: `Bearer lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx`
                        //'Content-Type': 'application/json'
                        //'Accept': 'application/json'
                        //'Accept-Encoding': 'gzip, deflate, br'
                    }
                });
                return response.data;
            }
            catch (error) {
                console.log(error);
            }
    },
    // create a new api call to retrieve a restaurant using the following api endpoint, bearer token, and an ID string at the end of the endpoint
    //Api endpoint: https://api.yelp.com/v3/businesses/
    //Bearer token: "lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx";

    async getRestaurant(id) {
            try {
                const response = await axios.get(`https://api.yelp.com/v3/businesses/${id}`, 
                return response.data;
            }
            catch (error) {
                console.log(error);
            }
    }
}



