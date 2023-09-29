import { Contact } from "./contact";
import { Gender } from "./gender";

export interface Person extends Contact {
    birthDate?: Date;
    gender: Gender;
}
