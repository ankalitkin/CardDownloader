using System;
using System.Collections.Generic;

namespace CardDownloader.Models
{
    public static class CardBacks
    {
        private static Dictionary<Guid, string> _dict;

        static CardBacks()
        {
            _dict = new Dictionary<Guid, string>()
            {
                {
                    new Guid("0aeebaf5-8c7d-4636-9e82-8c27447861f7"),
                    ""
                },
                {
                    new Guid("7840c131-f96b-4700-9347-2215c43156e6"),
                    "card-back-planechase-planechase"
                },
                {
                    new Guid("27d979ed-12f7-460d-a4fb-a8ae11ca7050"),
                    "card-back-black-back-2018-black-back-2018"
                },
                {
                    new Guid("597b79b3-7d77-4261-871a-60dd17403388"),
                    "card-back-oversized-commander-oversized-commander"
                },
                {
                    new Guid("2d53e50e-77d5-4353-9dde-0b1832d850f6"),
                    "card-back-heroes-of-the-realm-heroes-of-the-realm"
                },
                {
                    new Guid("98d277bf-8635-4a02-ac2f-4d44ddc47993"),
                    "card-back-contraption-contraption"
                },
                {
                    new Guid("bd3a2b8a-87c2-484d-8da3-dc891f4ee9a2"),
                    "card-back-meld-v17-brisela-top-meld-v17-brisela-top"
                },
                {
                    new Guid("7ca70503-7e97-4db0-99f9-4b9820f879f5"),
                    "card-back-meld-v17-brisela-bottom-meld-v17-brisela-bottom"
                },
                {
                    new Guid("1b2396d4-9048-439d-96bd-354288518841"),
                    "card-back-archenemy-archenemy"
                },
                {
                    new Guid("cef293c4-30f5-478b-9d2b-6fcc547d81e7"),
                    "card-back-meld-emn-hanweir-top-meld-emn-hanweir-top"
                },
                {
                    new Guid("028c1141-8613-47b1-9abf-5f660a213ebf"),
                    "card-back-meld-emn-hanweir-bottom-meld-emn-hanweir-bottom"
                },
                {
                    new Guid("9ebe2f6f-be19-4197-a7c2-bf470fce8882"),
                    "card-back-meld-emn-chittering-host-bottom-meld-emn-chittering-host-bottom"
                },
                {
                    new Guid("accc0344-6911-49cc-ace1-c10cc01a06c2"),
                    "card-back-meld-edm-chittering-host-top-meld-edm-chittering-host-top"
                },
                {
                    new Guid("431aff8a-4a63-43b2-8a91-604b5afe1fbb"),
                    "card-back-meld-emn-brisela-top-meld-emn-brisela-top"
                },
                {
                    new Guid("b226f2b2-3d2e-4a4f-92fc-0bb52ca107b3"),
                    "card-back-meld-emn-brisela-bottom-meld-emn-brisela-bottom"
                },
                {
                    new Guid("8e3d4e1e-82e6-4a0a-9b18-5a96683d24c2"),
                    "card-back-meld-pemn-hanweir-bottom-meld-pemn-hanweir-bottom"
                },
                {
                    new Guid("5b226b08-d7ee-494c-936f-4c12195f59a4"),
                    "card-back-meld-pemn-brisela-top-meld-pemn-brisela-top"
                },
                {
                    new Guid("0cb3b4d2-02e2-4436-9260-962501d0e5b1"),
                    "card-back-meld-pemn-brisela-bottom-meld-pemn-brisela-bottom"
                },
                {
                    new Guid("7d55a5bf-a837-4a75-9cc0-438bf320111f"),
                    "card-back-challenge-deck-3-challenge-deck-3"
                },
                {
                    new Guid("87d06f2c-46ff-4cad-9ee2-1a51b26f50cd"),
                    "card-back-challenge-deck-2-challenge-deck-2"
                },
                {
                    new Guid("f833d8b0-cc49-43db-a532-063453499528"),
                    "card-back-challenge-deck-1-challenge-deck-1"
                },
                {
                    new Guid("774519d7-8b63-46cd-98fc-7944b50d762c"),
                    "card-back-1996-pro-tour-decks-1996-pro-tour-decks"
                },
                {
                    new Guid("896307e5-1c5d-49c0-8fb5-8d1059bc1115"),
                    "card-back-2004-world-championship-decks-2004-world-championship-decks"
                },
                {
                    new Guid("0645a083-9e19-43db-9e76-4a424d53895d"),
                    "card-back-2003-world-championship-decks-2003-world-championship-decks"
                },
                {
                    new Guid("6bcbb89c-0af2-4510-8484-e59cc0042b09"),
                    "card-back-2002-world-championship-decks-2002-world-championship-decks"
                },
                {
                    new Guid("3c070ca1-0351-4b0b-ac81-cd083336c5ff"),
                    "card-back-coro-coro-coro-coro"
                },
                {
                    new Guid("420c2336-e212-4109-8525-b0fc69201351"),
                    "card-back-2001-world-championship-decks-2001-world-championship-decks"
                },
                {
                    new Guid("056eb595-ee96-4682-9206-1eaba1e88719"),
                    "card-back-2000-world-championship-decks-2000-world-championship-decks"
                },
                {
                    new Guid("dd587d92-6b8f-41ae-9cfa-1ad9879c9405"),
                    "card-back-gotta-special-version-gotta-special-version"
                },
                {
                    new Guid("87c0bf25-3f95-488a-836f-83464020cfaa"),
                    "card-back-gotta-1999-gotta-1999"
                },
                {
                    new Guid("407ed11d-7b6f-4e1c-ab00-f49c25f170e3"),
                    "card-back-1999-world-championship-decks-1999-world-championship-decks"
                },
                {
                    new Guid("df9a3149-dae5-4319-85bb-00d37c023360"),
                    "card-back-1998-world-championship-decks-1998-world-championship-decks"
                },
                {
                    new Guid("ae9f9ff4-cc75-4c6b-a029-cb9cc92a8502"),
                    "card-back-1997-world-championship-decks-1997-world-championship-decks"
                },
                {
                    new Guid("d3335a33-505d-422a-a03c-5dd9b1388046"),
                    "card-back-international-edition-international-edition"
                },
                {
                    new Guid("98784b63-d263-4abc-aabb-a092e6ecc788"),
                    "card-back-collectors-edition-collectors-edition"
                }
            };
        }

        public static string GetCardBackNameByGuid(Guid guid)
        {
            if (_dict.ContainsKey(guid))
                return _dict[guid];
            return guid.ToString();
        }
    }
}