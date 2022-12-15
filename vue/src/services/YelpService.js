import axios from 'axios';

export default {

  // create a new api call to retrieve restaurants using the following api endpoint and bearer token
  //Api endpoint: https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=
  //Bearer token: "lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx";
    async getRestaurants() {
        try 
        {
            const response = await axios.get(
                `https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=Cleveland`,//fix with this${location}
                { headers: { Authorization: `Bearer lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx`}});
                return response.data;
            }
        catch (error) 
        {
            console.log(error);
        }
    },
    // create a new api call to retrieve a restaurant using the following api endpoint, bearer token, and an ID string at the end of the endpoint
    //Api endpoint: https://api.yelp.com/v3/businesses/
    //Bearer token: "lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx";

    async getRestaurant(id) {
        //IDK IF THIS WORKS I HOPE IT DOES STILL GOTTA WIRE EVERYTHING UP
            try {
                const response = await axios.get(`https://api.yelp.com/v3/businesses/${id}`, 
                    { headers: { Authorization: `Bearer lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx`}});
                return response.data;
            }
            catch (error) {
                console.log(error);
            }
    }
}



