using TrainerEnglish.Users;

namespace TrainerEnglish.Application
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public RegistrationService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int RegisterUser(string nickname)
        {
            var newUserId = GetNewUserId();
            var newUserProfile = new UserProfile(newUserId, nickname, new Word[0]);
            _userProfileRepository.SaveUserProfile(newUserProfile);
            return newUserId;
        }

        private int GetNewUserId()
        {
            var userProfiles = _userProfileRepository.GetAllUserProfiles();
            var maxUserId = 1;
            foreach (var userProfile in userProfiles)
            {
                if (userProfile.Id > maxUserId)
                {
                    maxUserId = userProfile.Id;
                }
            }

            return maxUserId + 1;
        }
    }
}
