import * as axios from "axios";

const URL_PREFIX = "";

export function highSchoolTypeAhead(data) {
  return axios.post(URL_PREFIX + "/api/highschools/search", data);
}